using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu]
    public class FieldConfiguration : ScriptableObject
    {
        [SerializeField]
        private Vector3 startFieldPosition;
        [SerializeField]
        private GameObject gameField;

        public Vector3 StartFieldPosition => startFieldPosition;
        public GameObject GameField => gameField;
        public float FieldLength
        {
            get
            {
                return gameField.GetComponent<MeshFilter>().sharedMesh.bounds.size.x * gameField.transform.localScale.x;
            }
        }
    }
}