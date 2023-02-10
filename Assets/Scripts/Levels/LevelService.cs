using Enemy;
using UnityEngine;
using Zenject;


namespace Levels
{
    public class LevelService : MonoBehaviour
    {
        private EnemyFacade.Factory _enemyFactory;
        
        [Inject]
        private void Construct(EnemyFacade.Factory factory)
        {
            _enemyFactory = factory;
        }

        private void Start()
        {
            StartLevelCallBack(1);
        }


        private void StartLevelCallBack(int index)
        {
            _enemyFactory.Create(index);
        }
    }
}