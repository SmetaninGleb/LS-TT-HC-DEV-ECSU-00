using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu]
    class ProjectileTypeContainer : ScriptableObject
    {
        [SerializeField]
        private ProjectileType[] _projectileTypes;

        public ProjectileType[] ProjectileTypes => _projectileTypes;
    }
}
