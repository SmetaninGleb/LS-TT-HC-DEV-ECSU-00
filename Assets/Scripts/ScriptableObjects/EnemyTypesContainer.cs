
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu]
    class EnemyTypesContainer : ScriptableObject
    {
        [SerializeField]
        private EnemyType[] _enemyTypes;

        public EnemyType[] EnemyTypes => _enemyTypes;
    }
}
