using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu]
    class SpawnerType : ScriptableObject
    {
        [SerializeField]
        private GameObject _spawnerObject;

        public GameObject SpawnerObject => _spawnerObject;
    }
}
