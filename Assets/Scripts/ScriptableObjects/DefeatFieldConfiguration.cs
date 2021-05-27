using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu]
    class DefeatFieldConfiguration : ScriptableObject
    {
        [SerializeField]
        private GameObject _defeatField;
        [SerializeField]
        private Vector3 _position;

        public GameObject DefeatField => _defeatField;
        public Vector3 Position => _position;
        public float DefeatFieldLength
        {
            get
            {
                return _defeatField.GetComponent<MeshFilter>().sharedMesh.bounds.size.x * _defeatField.transform.localScale.x;
            }
        }
    }
}
