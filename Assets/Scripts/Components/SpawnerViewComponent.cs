using ScriptableObjects;
using UnityEngine;

namespace Components
{
    struct SpawnerComponent
    {
        private GameObject _spawnerObject;
        private SpawnerType _spawnerType;

        public SpawnerType SpawnerType
        {
            get { return _spawnerType; }
            set { _spawnerType = value; }
        }

        public GameObject SpawnerObject
        {
            get { return _spawnerObject; }
            set { _spawnerObject = value; }
        }
    }
}
