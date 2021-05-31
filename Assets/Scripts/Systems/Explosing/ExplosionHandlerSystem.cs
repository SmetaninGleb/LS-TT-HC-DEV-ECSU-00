using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    class ExplosionHandlerSystem : IEcsRunSystem
    {
        private EcsFilter<ProjectileComponent>.Exclude<ExplosionComponent> _projectileFilter;
        private EcsWorld _world;

        public void Run()
        {
            foreach (var index in _projectileFilter)
            {
                GameObject projectileObject = _projectileFilter.Get1(index).ProjectileObject;
                EcsEntity projectileEntity = _projectileFilter.GetEntity(index);
                if (isCollided(projectileObject))
                {
                    projectileEntity.Get<ExplosionComponent>().ExplosionObject = projectileObject;
                }
            }
        }

        private bool isCollided(GameObject projectileObject)
        {
            return projectileObject.GetComponent<ProjectileMonoBehaviour>().IsCollided;
        }
    }
}
