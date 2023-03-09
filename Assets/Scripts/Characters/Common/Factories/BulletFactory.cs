using Characters.Common;
using Zenject;

namespace Common.Factories
{
    public class BulletFactory : IFactory<Bullet>
    {
        private readonly DiContainer _diContainer;
        
        public BulletFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
        
        public Bullet Create()
        {
            return new Bullet(10);
        }
    }
}