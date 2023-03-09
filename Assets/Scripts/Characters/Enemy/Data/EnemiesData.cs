using Characters.Enemy;
using UnityEngine;

namespace Enemy.Data
{
    [CreateAssetMenu(fileName = "EnemiesData", menuName = "Enemy Data")]
    public class EnemiesData : ScriptableObject
    {
        [Header("Enemies Data")]
        public EnemyFacade[] EnemiesTypes;
    }
}