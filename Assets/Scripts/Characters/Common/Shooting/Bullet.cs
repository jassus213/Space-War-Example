using System;
using Characters.Common.Interfaces;
using UnityEngine;
using Zenject;

namespace Characters.Common.Shooting
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour, IBullet
    {
        private const int DAMAGE = 5;
        private Rigidbody2D _rigidbody2D => gameObject.GetComponent<Rigidbody2D>();

        private void Start()
        {
            _rigidbody2D.velocity = transform.up * 50;
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.TryGetComponent<IDamageable>(out var character))
            {
                character.GetDamage(DAMAGE);
            }
            
            Destroy(gameObject);
        }

        public class Factory : PlaceholderFactory<Transform, Bullet>
        {
        }
    }
}