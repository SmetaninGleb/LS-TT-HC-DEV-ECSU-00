using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    class ExplosionSystem : IEcsRunSystem
    {
        private EcsFilter<ProjectileComponent, ExplosionComponent> _explosionFilter;

        public void Run()
        {
            foreach (var index in _explosionFilter)
            {
                GameObject projectileObject = _explosionFilter.Get1(index).ProjectileObject;
                GameObject.Destroy(projectileObject);
                _explosionFilter.GetEntity(index).Destroy();
            }
        }
    }
}
