using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu]
    class SpawnerContainer : ScriptableObject
    {
        [SerializeField]
        private Spawner[] _spawners;

        public Spawner[] Spawners => _spawners;
    }
}
