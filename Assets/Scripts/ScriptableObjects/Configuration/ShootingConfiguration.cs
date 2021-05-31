using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu]
    class ShootingConfiguration : ScriptableObject
    {
        [SerializeField]
        private float _projectileSpawnHeight;
        [SerializeField]
        private float _reloadTime;

        public float ProjectileSpawnHeight => _projectileSpawnHeight;
        public float ReloadTime => _reloadTime;
    }
}
