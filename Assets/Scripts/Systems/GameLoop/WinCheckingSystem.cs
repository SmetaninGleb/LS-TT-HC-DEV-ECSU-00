using Leopotam.Ecs;
using ScriptableObjects;
using UnityEngine;
using Components;

namespace Systems
{
    class WinCheckingSystem : IEcsRunSystem
    {
        private EcsFilter<WinTrackerComponent> _winFilter;
        private EcsFilter<IsOnGameTrackerComponent> _isOnGameTrackerFilter;
        private EcsFilter<EndTimeTrackerComponent> _endTimeTrackerFilter;
        private EcsFilter<EnemyComponent> _enemyFilter;
        private GameConfiguration _gameConfigurations;
        private EcsWorld _world;

        public void Run()
        {
            if (!_isOnGameTrackerFilter.IsEmpty())
            {
                if (_winFilter.IsEmpty() && !_endTimeTrackerFilter.IsEmpty() && _enemyFilter.IsEmpty())
                {
                    EcsEntity winEntity = _world.NewEntity();
                    winEntity.Get<WinTrackerComponent>();
                    DeleteAllEntitiesInFilter(_isOnGameTrackerFilter);
                    DeleteAllEntitiesInFilter(_endTimeTrackerFilter);
                }
            }
        }

        private void DeleteAllEntitiesInFilter (EcsFilter filter)
        {
            foreach (var index in filter)
            {
                filter.GetEntity(index).Destroy();
            }
        }
    }
}
