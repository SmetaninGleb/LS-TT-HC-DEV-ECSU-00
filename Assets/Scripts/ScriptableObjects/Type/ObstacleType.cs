using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu]
    class ObstacleType : ScriptableObject
    {
        [SerializeField]
        private GameObject _obstacleObject;
        [SerializeField]
        private int _numberOfObstacles;
        [SerializeField]
        private float _spawnHeight;
        [SerializeField]
        private float _maxForceOnObstacle;

        public GameObject ObstacleObject => _obstacleObject;
        public int NumberOfObstacles => _numberOfObstacles;
        public float SpawnHeight => _spawnHeight;
        public float MaxForceOnObstacle => _maxForceOnObstacle;
    }
}
