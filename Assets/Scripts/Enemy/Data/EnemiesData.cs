using UnityEngine;

namespace Enemy.Data
{
    [CreateAssetMenu(fileName = "EnemiesData", menuName = "Enemy Data")]
    public class EnemiesData : ScriptableObject
    {
        public EnemyFacade[] EnemiesTypes;
    }
}