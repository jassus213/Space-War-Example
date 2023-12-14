using Characters.Common.Interfaces;
using Characters.Player.Model.Interfaces;
using UnityEngine;
using Zenject;

namespace Characters.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerFacade : MonoBehaviour, IDamageable
    {
        private Rigidbody2D _rigidbody => gameObject.GetComponent<Rigidbody2D>();
        public Transform Transform => gameObject.transform;
        
        private IModel _model;

        [Inject]
        public void Constructor(IModel model)
        {
            _model = model;
        }

        public void GetDamage(float damage)
        {
            _model.TakeDamage(damage);
        }
    }
}