using Leopotam.Ecs;
using Components;
using UnityEngine;

namespace Systems
{
    class StartGameTrackerSystem : IEcsRunSystem
    {
        private EcsFilter<StartGameComponent> _startFilter;
        private EcsFilter<BeforeStartTrackerComponent> _beforeStartFilter;
        private EcsWorld _world;

        public void Run()
        {
            if (!_startFilter.IsEmpty())
            {
                DeleteBeforeStartEntities();
                DeleteStartEntities();
                EcsEntity onGameEntity = _world.NewEntity();
                onGameEntity.Get<IsOnGameTrackerComponent>().StartTime = Time.timeSinceLevelLoad;
            }
        }

        private void DeleteStartEntities()
        {
            foreach (int index in _startFilter)
            {
                _startFilter.GetEntity(index).Destroy();
            }
        }

        private void DeleteBeforeStartEntities()
        {
            foreach (int index in _beforeStartFilter)
            {
                _beforeStartFilter.GetEntity(index).Destroy();
            }
        }
    }
}
