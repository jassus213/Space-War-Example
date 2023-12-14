using System;
using System.Collections.Generic;
using Characters.Common;
using Characters.Common.Factories;
using Characters.Common.Handlers;
using Characters.Common.Shooting;
using Characters.Player.Handlers;
using Characters.Player.Input;
using Characters.Player.Model;
using UnityEngine;
using Zenject;

namespace Characters.Player.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] Settings _settings = null;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PlayerFacade>().FromInstance(_settings.PlayerFacade).AsSingle();

            Container.BindInterfacesAndSelfTo<PlayerModel>().AsCached()
                .WithArguments(_settings.Rigidbody, _settings.Transform);

            Container.BindInterfacesAndSelfTo<InputHandler>().AsSingle();
            Container.Bind<InputState>().AsSingle();

            Container.BindInterfacesAndSelfTo<MoveHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<HealthHandler>().AsCached();
            var queue = new Queue<Transform>(_settings.ShootPositions);
            Container.BindInterfacesAndSelfTo<ShootingHandler>().AsCached().WithArguments(queue);

            Container.BindFactory<Transform, Bullet, Bullet.Factory>()
                .FromFactory<BulletFactory>();
        }

        [Serializable]
        public class Settings
        {
            public Rigidbody2D Rigidbody;
            public Transform Transform;
            public PlayerFacade PlayerFacade;

            public Transform[] ShootPositions;
        }
    }
}