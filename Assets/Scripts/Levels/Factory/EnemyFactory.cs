using System.Collections.Generic;
using Characters.Enemy;
using Enemy;
using Enemy.Data;
using Unity.Mathematics;
using UnityEngine;
using Zenject;
using EnemyFacade = Characters.Enemy.EnemyFacade;
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
            var positions = GetRandomPositionInWorld(levelIndex, countOfEnemies);
            List<EnemyFacade> enemies = new List<EnemyFacade>();

            for (var i = 0; i < countOfEnemies; i++)
            {
                var enemyType = _enemiesData.EnemiesTypes[GetRandomTypeShip()];
                var enemy = CreateEnemy(enemyType, positions[i]);
                var stateMachine = new StateMachine(_signalBus);
                var enemyModel = new EnemyModel(enemy.Rigidbody, enemy.transform);
                enemy.Construct(stateMachine, enemyModel);
                enemies.Add(enemyType);
            }

            return enemies.ToArray();
        }


        private EnemyFacade CreateEnemy(EnemyFacade enemyType, Vector3 position)
        {
            var enemy = _diContainer.InstantiatePrefabForComponent<EnemyFacade>(enemyType, position, quaternion.identity, null);
            return enemy;
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
                resultVectors.Add(pos.transform.position);
            }

            return resultVectors.ToArray();
        }

        private int GetRandomCountOfEnemies(int levelIndex)
        {
            return Random.Range(1, _dataLevels.LevelSettings[levelIndex].Length);
        }
    }
}