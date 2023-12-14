using Characters.Common.Shooting;
using UnityEngine;
using Zenject;

namespace Characters.Common.Factories
{
    public class BulletFactory : IFactory<Transform, Bullet>
    {
        private readonly IInstantiator _instantiator;
        private static GameObject Prefab => Resources.Load<GameObject>("Bullet");
        
        public BulletFactory(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        public Bullet Create(Transform param)
        {
            var bullet = _instantiator.InstantiatePrefabForComponent<Bullet>(Prefab, param.position, param.rotation, null);
            return bullet;
        }
    }
}