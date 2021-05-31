using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu]
    class ProjectileType : ScriptableObject
    {
        [SerializeField]
        private float _explosionRadius;
        [SerializeField]
        private float _flightForceMultiplier;
        [SerializeField]
        private GameObject _projectileObject;
        [SerializeField]
        private GameObject _uiProjectileObject;
        [SerializeField]
        private GameObject _explosionParticlesObject;
        [SerializeField]
        private int _damage;
        [SerializeField]
        private float _maxForceToObstacle;

        public float ExplosionRadius => _explosionRadius;
        public float FlightForceMultiplier => _flightForceMultiplier;
        public GameObject ProjectileObject => _projectileObject;
        public GameObject UIProjectileObject => _uiProjectileObject;
        public GameObject ExplosionParticleObject => _explosionParticlesObject;
        public int Damage => _damage;
        public float MaxForceToObstacle => _maxForceToObstacle;
    }
}
