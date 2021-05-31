using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu]
    class ObstacleTypesContainer : ScriptableObject
    {
        [SerializeField]
        private ObstacleType[] _obstacleTypes;

        public ObstacleType[] ObstacleTypes => _obstacleTypes;
    }
}
