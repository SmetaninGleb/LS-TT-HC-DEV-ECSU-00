using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    class RayFromTouchSystem : IEcsRunSystem
    {
        private EcsFilter<TouchComponent> _touchFilter;
        private EcsFilter<RayComponent> _rayFilter;
        private EcsFilter<FieldViewComponent> _fieldViewFilter;
        private EcsWorld _world;

        public void Run()
        {
            foreach (var index in _rayFilter)
            {
                _rayFilter.GetEntity(index).Destroy();
            }

            foreach (var index in _touchFilter)
            {
                Touch touch = _touchFilter.Get1(index).Touch;
                if (touch.phase == TouchPhase.Began)
                {
                    Vector3 touchPosition = touch.position;
                    Camera camera = _fieldViewFilter.Get1(0).FieldObject.GetComponentInChildren<Camera>();
                    Ray ray = camera.ScreenPointToRay(touchPosition);
                    EcsEntity rayEntity = _world.NewEntity();
                    rayEntity.Get<RayComponent>().Ray = ray;
                }
            }
        }
    }
}
