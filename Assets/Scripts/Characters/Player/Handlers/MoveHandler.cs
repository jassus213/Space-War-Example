using Characters.Player.Input;
using Characters.Player.Model.Interfaces;
using Player.Signals;
using UnityEngine;
using Zenject;

namespace Characters.Player.Handlers
{
    public class MoveHandler : IFixedTickable
    {
        private readonly float _defaultSpeed = 150;
        private readonly float _acceleratingSpeed = 500;
        private float _currentSpeed;
        private readonly float _rotationSpeed = 100;


        private Vector2 _movementDirection;

        private readonly InputState _inputState;
        private readonly IMovable _playerModel;
        private readonly SignalBus _signalBus;

        public MoveHandler(InputState inputState, IMovable playerModel, SignalBus signalBus)
        {
            _inputState = inputState;
            _playerModel = playerModel;
            _signalBus = signalBus;
        }


        public void FixedTick()
        {
            _signalBus.TryFire(new PlayerSignals.PlayerChangePos { PlayerPos = _playerModel.Position});
            
            if (_inputState.AxisRawHorizontal == 0 && _inputState.AxisRawVertical == 0)
                return;

            _currentSpeed = _inputState.IsAccelerating ? _acceleratingSpeed : _defaultSpeed;

            Move();

            Rotate();
        }


        private void Move()
        {
            _movementDirection = new Vector2(_inputState.AxisRawHorizontal,
                _inputState.AxisRawVertical).normalized;
            var resultDirection = new Vector2(_movementDirection.x * _currentSpeed * Time.fixedDeltaTime,
                _movementDirection.y * _currentSpeed * Time.fixedDeltaTime);
            
            _playerModel.Move(resultDirection);
        }

        private void Rotate()
        {
            var fixedVector = new Vector2(_movementDirection.x, _movementDirection.y);
            var rotationVector = Quaternion.LookRotation(-Vector3.forward, fixedVector);
            _playerModel.Rotate(rotationVector, _rotationSpeed);
        }
    }
}