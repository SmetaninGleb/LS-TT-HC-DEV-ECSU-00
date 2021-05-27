using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu]
    class ProjectileType : ScriptableObject
    {
        [SerializeField]
        private float _explosionRadius;
        [SerializeField]
        private float _forceMultiplier;
        [SerializeField]
        private GameObject _projectileObject;
        [SerializeField]
        private int _damage;

        public float ExplosionRadius => _explosionRadius;
        public float ForceMultiplier => _forceMultiplier;
        public GameObject ProjectileObject => _projectileObject;
        public int Damage => _damage;
    }
}
