using UnityEngine;


namespace ScriptableObjects
{
    [CreateAssetMenu]
    class NavMeshConfiguration : ScriptableObject
    {
        [SerializeField]
        private GameObject _navMesh;


        public GameObject NavMesh => _navMesh;
    }
}
