using UnityEngine;


namespace ScriptableObjects
{
    [CreateAssetMenu]
    class NavMeshConfiguration : ScriptableObject
    {
        [SerializeField]
        private GameObject _navMesh;
        [SerializeField]
        private string _ignoreLayerName;


        public GameObject NavMesh => _navMesh;
        public string IgnoreLayerName => _ignoreLayerName;
    }
}
