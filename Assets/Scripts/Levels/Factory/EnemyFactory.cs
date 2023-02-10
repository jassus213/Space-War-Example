using System.Collections.Generic;
using Enemy;
using Enemy.Data;
using Unity.Mathematics;
using UnityEngine;
using Zenject;
using EnemyFacade = Enemy.EnemyFacade;
using Random = UnityEngine.Random;

namespace Levels.Factory
{
    public class EnemyFactory : IFactory<int, EnemyFacade[]>
    {
        private readonly DataLevels _dataLevels;
        private readonly EnemiesData _enemiesData;
        private readonly DiContainer _diContainer;
        private readonly SignalBus _signalBus;

        public EnemyFactory(DataLevels dataLevels, EnemiesData enemiesData, DiContainer diContainer,
            SignalBus signalBus)
        {
            _dataLevels = dataLevels;
            _enemiesData = enemiesData;
            _diContainer = diContainer;
            _signalBus = signalBus;
        }

        public EnemyFacade[] Create(int levelIndex)
        {
            var countOfEnemies = GetRandomCountOfEnemies(levelIndex);
            var postions = GetRandomPositionInWorld(levelIndex, countOfEnemies);
            List<EnemyFacade> enemies = new List<EnemyFacade>();

            for (int i = 0; i < countOfEnemies; i++)
            {
                var enemyType = _enemiesData.EnemiesTypes[GetRandomTypeShip()];
                var enemy = _diContainer.InstantiatePrefab(enemyType, postions[i], quaternion.identity, null);
                var stateMachine = new StateMachine(_signalBus);
                enemy.GetComponent<EnemyFacade>().Construct(stateMachine);
                enemies.Add(enemyType);
            }

            return enemies.ToArray();
        }

        private int GetRandomTypeShip()
        {
            return Random.Range(0, _enemiesData.EnemiesTypes.Length);
        }

        private Vector3[] GetRandomPositionInWorld(int levelIndex, int countOfEnemies)
        {
            //TODO Get ray positions by index level
            var arrayOfPositions = _dataLevels.LevelSettings[0];
            List<Vector3> resultVectors = new List<Vector3>();

            for (int i = 0; i < countOfEnemies; i++)
            {
                //TODO Eliminate the possibility of spawning at one point
                var rnd = Random.Range(0, arrayOfPositions.Length);
                var pos = arrayOfPositions[rnd];
                resultVectors.Add(pos);
            }

            return resultVectors.ToArray();
        }

        private int GetRandomCountOfEnemies(int levelIndex)
        {
            return Random.Range(1, _dataLevels.LevelSettings[levelIndex].Length);
        }
    }
}