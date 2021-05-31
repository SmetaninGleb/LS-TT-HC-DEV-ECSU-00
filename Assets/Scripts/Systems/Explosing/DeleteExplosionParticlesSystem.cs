using Leopotam.Ecs;
using Components;
using UnityEngine;
using static UnityEngine.ParticleSystem;

namespace Systems
{
    class DeleteExplosionParticlesSystem : IEcsRunSystem
    {
        private EcsFilter<ExplosionParticlesComponent> _explosionParticlesFilter;

        public void Run()
        {
            foreach (var explosionIndex in _explosionParticlesFilter)
            {
                ref ExplosionParticlesComponent particleComponent = ref _explosionParticlesFilter.Get1(explosionIndex);
                GameObject particlesObject = particleComponent.ParticlesObject;
                ParticleSystem unityParticleSystem = particlesObject.GetComponent<ParticleSystem>();
                if (!unityParticleSystem.IsAlive())
                {
                    GameObject.Destroy(particlesObject);
                    _explosionParticlesFilter.GetEntity(explosionIndex).Destroy();
                }
            }
        }
    }
}
