using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    class RaycastHandlerSystem : IEcsRunSystem
    {
        private EcsFilter<RayComponent> _rayFilter;
        private EcsFilter<RaycastHitComponent> _raycastHitFilter;
        private EcsWorld _world;

        public void Run()
        {
            foreach (var index in _raycastHitFilter)
            {
                _raycastHitFilter.GetEntity(index).Destroy();
            }

            foreach (var index in _rayFilter)
            {
                Ray ray = _rayFilter.Get1(index).Ray;
                RaycastHit hit;
                Physics.Raycast(ray, out hit);
                EcsEntity raycastHitEntity = _world.NewEntity();
                raycastHitEntity.Get<RaycastHitComponent>().Hit = hit;
            }
        }
    }
}
