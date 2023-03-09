using Characters.Player.Model.Interfaces;
using UnityEngine;

namespace Characters.Player.Model
{
    public class PlayerModel : IModel, IMovable
    {
        public Quaternion Rotation => _transform.rotation;
        public Vector3 Position => _rigidbody.position;
        public float Health => _currentHealth;
        private float _currentHealth;
        public bool IsDead { get; }
        private readonly Rigidbody2D _rigidbody;
        private readonly float _maxHealth = 100;

        public Transform Transform => _transform;
        private readonly Transform _transform;

        
        public PlayerModel(Rigidbody2D rigidbody, Transform transform)
        {
            _rigidbody = rigidbody;
            _transform = transform;
        }
        
        public void TakeDamage(float damage)
        {
            _currentHealth -= damage;
        }
        
        public void Move(Vector2 direction)
        {
            _rigidbody.MovePosition(_rigidbody.position + direction * Time.fixedDeltaTime);
        }

        public void Rotate(Quaternion quaternion, float rotationSpeed)
        {
            _transform.rotation = Quaternion.RotateTowards(_transform.rotation, quaternion, rotationSpeed);
        }
    }
}