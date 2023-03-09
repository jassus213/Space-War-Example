using Characters.Common.Interfaces;
using UnityEngine;

namespace Characters.Common
{
    public class Bullet : MonoBehaviour, IBullet
    { 
        private readonly int _damage;

        public Bullet(int damage)
        {
            _damage = damage;
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            var character = col.gameObject.GetComponent<ICanGetDamage>();
            if (character != null)
                character.GetDamage(_damage);
        }
    }
}