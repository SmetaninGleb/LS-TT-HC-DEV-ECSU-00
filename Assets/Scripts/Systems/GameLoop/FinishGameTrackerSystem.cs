using Leopotam.Ecs;
using Components;

namespace Systems
{
    class FinishGameTrackerSystem : IEcsRunSystem
    {
        private EcsFilter<FinishGameTrackerComponent> _finishFilter;
        private EcsFilter<WinTrackerComponent> _winTrackerFilter;
        private EcsFilter<DefeatTrackerComponent> _defeatTrackerFilter;
        private EcsFilter<IsOnGameTrackerComponent> _isOnGameFilter;
        private EcsWorld _world;

        public void Run()
        {
            if (!_finishFilter.IsEmpty())
            {
                DeleteAllEntitiesInFilter(_isOnGameFilter);
                DeleteAllEntitiesInFilter(_finishFilter);
                DeleteAllEntitiesInFilter(_winTrackerFilter);
                DeleteAllEntitiesInFilter(_defeatTrackerFilter);
                EcsEntity beforeStartEntity = _world.NewEntity();
                beforeStartEntity.Get<BeforeStartTrackerComponent>();
            }
        }
        
        private void DeleteAllEntitiesInFilter(EcsFilter filter)
        {
            foreach (var index in filter)
            {
                filter.GetEntity(index).Destroy();
            }
        }
    }
}
