using Components;
using Leopotam.Ecs;
using ScriptableObjects;
using UnityEngine;

namespace Systems
{
    class ProjectileTypeOrderSystem : IEcsRunSystem
    {
        private EcsFilter<NextProjectileComponent> _nextProjectileFiter;

        private ProjectileTypeContainer _projectileTypeContainter; 
        private EcsWorld _world;

        public void Run()
        {
            if (_nextProjectileFiter.IsEmpty())
            {
                EcsEntity nextProjectileEntity = _world.NewEntity();
                int randomProjectileTypeIndex = Random.Range(0, _projectileTypeContainter.ProjectileTypes.Length);
                nextProjectileEntity.Get<NextProjectileComponent>().ProjectileType = _projectileTypeContainter.ProjectileTypes[randomProjectileTypeIndex];
            }
        }
    }
}
