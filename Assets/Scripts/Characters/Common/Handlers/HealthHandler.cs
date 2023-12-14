using Characters.Player.Model.Interfaces;
using Zenject;

namespace Characters.Common.Handlers
{
    public class HealthHandler : IHealthHandler
    {
        private readonly IModel _model;
        private readonly SignalBus _signalBus;

        public HealthHandler(IModel model, SignalBus signalBus)
        {
            _model = model;
            _signalBus = signalBus;
        }

        public void HandleDamage(float damage)
        {
            _model.TakeDamage(damage);
            
            if (_model.Health <= 0)
                HandleDie();
        }

        private void HandleDie()
        {
            
        }
        
    }
}