using Characters.Player.Model.Interfaces;
using UnityEngine;

namespace Characters.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerFacade : MonoBehaviour
    {
        public bool IsDead => _model.IsDead;
        private Rigidbody2D _rigidbody => gameObject.GetComponent<Rigidbody2D>();
        public Transform Transform => gameObject.transform;
        
        private readonly IModel _model;

        public PlayerFacade(IModel model)
        {
            _model = model;
        }

        public void TakeDamage(float damage)
        {
            _model.TakeDamage(damage);
        }
    }
}