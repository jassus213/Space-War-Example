using Characters.Enemy;
using DefaultNamespace.Signals;
using Enemy;
using Enemy.Data;
using Levels.Factory;
using UnityEngine;
using Zenject;

namespace Levels.Installers
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private ScriptableObject levelData;
        [SerializeField] private ScriptableObject enemiesData;
        [SerializeField] private LevelService levelService;
        
        public override void InstallBindings()
        {
            #region Signals

            Container.DeclareSignal<LevelSignals.StartLevel>().OptionalSubscriber();

            #endregion

            #region Factories

            Container.BindFactory<int, EnemyFacade[], EnemyFacade.Factory>().FromFactory<EnemyFactory>();

            #endregion

            #region ScriptableObjects

            Container.Bind<DataLevels>().FromScriptableObject(levelData).AsSingle();
            Container.Bind<EnemiesData>().FromScriptableObject(enemiesData).AsSingle();

            #endregion

            #region Other

            Container.Bind<LevelService>().FromInstance(levelService).AsSingle();

            #endregion
        }
    }
}