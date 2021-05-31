
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu]
    class SpawnConfiguration : ScriptableObject
    {
        [SerializeField]
        private float spawnTimeRange;

        public float SpawnTimeRange => spawnTimeRange;
    }
}
