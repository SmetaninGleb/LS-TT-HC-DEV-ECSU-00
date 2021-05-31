using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    class DefeatCheckingSystem : IEcsRunSystem
    {
        private EcsFilter<DefeatFieldComponent> _defeatFieldFilter;
        private EcsFilter<IsOnGameTrackerComponent> _isOnGameTrackerFilter;
        private EcsFilter<DefeatTrackerComponent> _defeatTrackerFilter;
        private EcsFilter<EndTimeTrackerComponent> _endTimeTrackerFilter;
        private EcsWorld _world;

        public void Run()
        {
            bool isDefeat = true;
            foreach(var index in _defeatFieldFilter)
            {
                if (!_defeatFieldFilter.Get1(index).DefeatFieldObject.GetComponent<DefeatFieldMonoBehaviour>().IsEnemyCollided)
                {
                    isDefeat = false;
                }
            }

            if (isDefeat && _defeatTrackerFilter.IsEmpty() && !_isOnGameTrackerFilter.IsEmpty())
            {
                EcsEntity defeatEntity = _world.NewEntity();
                defeatEntity.Get<DefeatTrackerComponent>();
                DeleteAllEntitiesInFilter(_isOnGameTrackerFilter);
                DeleteAllEntitiesInFilter(_endTimeTrackerFilter);
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
