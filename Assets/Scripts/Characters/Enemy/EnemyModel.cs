using Characters.Player.Model.Interfaces;
using UnityEngine;

namespace Characters.Enemy
{
    public class EnemyModel : IModel
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

        
        public EnemyModel(Rigidbody2D rigidbody, Transform transform)
        {
            _rigidbody = rigidbody;
            _transform = transform;

            _currentHealth = _maxHealth;
        }
        
        public void TakeDamage(float damage)
        {
            _currentHealth -= damage;
        }
    }
}