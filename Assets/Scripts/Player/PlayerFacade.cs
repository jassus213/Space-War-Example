using Player.Model.Interfaces;
using UnityEngine;

namespace Player
{
    public class PlayerFacade : MonoBehaviour
    {
        public bool IsDead => _model.IsDead;
        
        private readonly IModel _model;

        public PlayerFacade(IModel model)
        {
            _model = model;
        }

        public void TakeDamage(float damage)
        {
        }
    }
}