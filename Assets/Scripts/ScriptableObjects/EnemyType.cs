
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu]
    class EnemyType : ScriptableObject
    {
        [SerializeField]
        private GameObject _enemyObject;
        [SerializeField]
        private float _enemySpeed;

        public GameObject EnemyObject => _enemyObject;
        public float EnemySpeed => _enemySpeed;
    }
}
