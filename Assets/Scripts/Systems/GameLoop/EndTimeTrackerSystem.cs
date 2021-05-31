using Leopotam.Ecs;
using Components;
using UnityEngine;
using ScriptableObjects;

namespace Systems
{
    class EndTimeTrackerSystem : IEcsRunSystem
    {
        private EcsFilter<IsOnGameTrackerComponent> _isOnGameFilter;
        private EcsFilter<EndTimeTrackerComponent> _endTimeTrackerFilter;
        private GameConfiguration _gameConfiguration;
        private EcsWorld _world;
        
        public void Run()
        {
            if (!_isOnGameFilter.IsEmpty() && _endTimeTrackerFilter.IsEmpty())
            {
                if (Time.timeSinceLevelLoad - _isOnGameFilter.Get1(0).StartTime >= _gameConfiguration.TimeToWin)
                {
                    EcsEntity endTimeEntity = _world.NewEntity();
                    endTimeEntity.Get<EndTimeTrackerComponent>();
                }
            }
        }
    }
}
