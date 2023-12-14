using System.Collections.Generic;
using Characters.Common.Shooting;
using Characters.Player.Input;
using UnityEngine;
using Zenject;

namespace Characters.Common
{
    public class ShootingHandler : ITickable
    {
        private readonly InputState _inputState;
        private readonly Queue<Transform> _shootPosition;
        private readonly Bullet.Factory _factory;

        private const float COOLDOWN = 1;
        private float _lastShot;

        public ShootingHandler(InputState inputState, Queue<Transform> shootPosition, Bullet.Factory factory)
        {
            _inputState = inputState;
            _shootPosition = shootPosition;
            _factory = factory;
        }

        public void Tick()
        {
            if (_inputState.IsFiring && Time.time - _lastShot > COOLDOWN)
            {
                var position = _shootPosition.Dequeue();
                var bullet = _factory.Create(position);
                _shootPosition.Enqueue(position);
                _lastShot = Time.time;
            }
        }

        private void Shoot()
        {
        }
    }
}