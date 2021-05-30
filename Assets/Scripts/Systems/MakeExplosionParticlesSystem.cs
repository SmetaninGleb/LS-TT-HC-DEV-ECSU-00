using Leopotam.Ecs;
using UnityEngine;
using Components;

namespace Systems
{
    class MakeExplosionParticlesSystem : IEcsRunSystem
    {
        private EcsFilter<ProjectileComponent, ExplosionComponent>.Exclude<ProjectileExplosionParticleComponent> _explosionFilter;
        private EcsWorld _world;
        
        public void Run()
        {
            foreach (var index in _explosionFilter)
            {
                EcsEntity explosionEntity = _explosionFilter.GetEntity(index);
                ref ProjectileComponent projectileComponent = ref explosionEntity.Get<ProjectileComponent>();
                GameObject projectileObject = projectileComponent.ProjectileObject;
                GameObject particleObject = projectileComponent.ProjectileType.ExplosionParticleObject;
                GameObject particleInstObject = GameObject.Instantiate(particleObject, projectileObject.transform.position, Quaternion.identity);
                EcsEntity explosionParticleEntity = _world.NewEntity();
                explosionParticleEntity.Get<ExplosionParticlesComponent>().ParticlesObject = particleInstObject;
                explosionEntity.Get<ProjectileExplosionParticleComponent>().ParticlesObject = particleInstObject;
            }
        }
    }
}
