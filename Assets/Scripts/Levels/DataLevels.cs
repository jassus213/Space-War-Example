using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Levels
{
    [CreateAssetMenu(fileName = "NewLevel", menuName = "Scene Data/Level")]
    public class DataLevels : ScriptableObject
    {
        [Header("PossibleSpawns")] 
        [SerializeField] private Transform[] firstLevelSpawns;
        [SerializeField] private Transform[] secondLevelSpawns;


        public Dictionary<int, Transform[]> LevelSettings;

        [Inject]
        private void Construct()
        {
            LevelSettings = new Dictionary<int, Transform[]>()
            {
                {0, firstLevelSpawns},
                {1, secondLevelSpawns}
            };
        }
    }
}