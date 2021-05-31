using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu]
    class ObstacleSpawnConfiguration : ScriptableObject
    {
        [SerializeField]
        private float xTopPadding;
        [SerializeField]
        private float xBottomPadding;
        [SerializeField]
        private float zPadding;

        public float XTopPadding => xTopPadding;
        public float XBottomPadding => xBottomPadding;
        public float ZPadding => zPadding;
    }
}
