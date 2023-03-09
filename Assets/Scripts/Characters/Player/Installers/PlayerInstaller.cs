using System;
using Characters.Player.Handlers;
using Characters.Player.Model;
using Player.InputHandler;
using Player.Signals;
using UnityEngine;
using Zenject;

namespace Player.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] Settings _settings = null;

        public override void InstallBindings()
        {
            #region Signals

            

            #endregion
            
            Container.Bind<PlayerModel>().AsSingle()
                .WithArguments(_settings.Rigidbody, _settings.Transform);

            Container.BindInterfacesAndSelfTo<InputHandler.InputHandler>().AsSingle();
            Container.Bind<InputState>().AsSingle();

            Container.BindInterfacesAndSelfTo<MoveHandler>().AsSingle();
        }

        [Serializable]
        public class Settings
        {
            public Rigidbody2D Rigidbody;
            public Transform Transform;
        }
    }
}