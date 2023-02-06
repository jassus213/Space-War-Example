using Player.InputHandler;
using Player.Model;
using UnityEngine;
using Zenject;

namespace Player.Handlers
{
    public class MoveHandler : IFixedTickable
    {
        private readonly float _defaultSpeed = 100;
        private readonly float _runningSpeed = 125;
        private readonly float _rotationSpeed = 100;
        

        private Vector2 _movementDirection;

        private readonly InputState _inputState;
        private readonly PlayerModel _playerModel;

        public MoveHandler(InputState inputState, PlayerModel playerModel)
        {
            _inputState = inputState;
            _playerModel = playerModel;
        }


        public void FixedTick()
        {
            if (_inputState.AxisRawHorizontal == 0 && _inputState.AxisRawVertical == 0)
                return;
        
            Move(); 

            Rotate();
        }


        private void Move()
        {
            _movementDirection = new Vector2(_inputState.AxisRawHorizontal,
                _inputState.AxisRawVertical).normalized;
            var resultDirection = new Vector2(_movementDirection.x * _defaultSpeed * Time.fixedDeltaTime,
                _movementDirection.y * _defaultSpeed * Time.fixedDeltaTime);

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