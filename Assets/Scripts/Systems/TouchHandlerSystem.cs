using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    class TouchHandlerSystem : IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter<TouchComponent> _touchFilter;

        public void Run()
        {
            foreach (var index in _touchFilter)
            {
                _touchFilter.GetEntity(index).Destroy();
            }

            for (int i = 0; i < Input.touchCount; i++)
            {
                EcsEntity touchEntity = _world.NewEntity();
                touchEntity.Get<TouchComponent>().Touch = Input.GetTouch(i);

            }
        }
    }
}
