using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu]
    class DefeatFieldConfiguration : ScriptableObject
    {
        [SerializeField]
        private GameObject _defeatField;
        [SerializeField]
        private float _defeatFieldLength;
        [SerializeField]
        private Vector3 _position;

        public GameObject DefeatField => _defeatField;
        public Vector3 Position => _position;
        public float DefeatFieldLength => _defeatFieldLength;
    }
}
