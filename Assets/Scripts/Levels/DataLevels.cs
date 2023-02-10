using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Levels
{
    [CreateAssetMenu(fileName = "NewLevel", menuName = "Scene Data/Level")]
    public class DataLevels : ScriptableObject
    {
        [Header("PossibleSpawns")] 
        public Vector3[] FirstLevelSpawns;
        public Vector3[] SecondLevelSpawns;


        public Dictionary<int, Vector3[]> LevelSettings;

        [Inject]
        private void Consturct()
        {
            LevelSettings = new Dictionary<int, Vector3[]>()
            {
                {0, FirstLevelSpawns},
                {1, SecondLevelSpawns}
            };
        }
    }
}