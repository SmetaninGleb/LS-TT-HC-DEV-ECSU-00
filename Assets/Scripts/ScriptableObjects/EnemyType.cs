
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
        [SerializeField]
        private int _healthPoints;

        public GameObject EnemyObject => _enemyObject;
        public float EnemySpeed => _enemySpeed;
        public int HealthPoints => _healthPoints;
    }
}
