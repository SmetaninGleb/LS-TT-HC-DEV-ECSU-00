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
        private GameConfiguration _gameConfigurations;
        private EcsWorld _world;

        public void Run()
        {
            if (!_isOnGameTrackerFilter.IsEmpty())
            {
                if (_winFilter.IsEmpty() && Time.timeSinceLevelLoad - _isOnGameTrackerFilter.Get1(0).StartTime > _gameConfigurations.TimeToWin)
                {
                    EcsEntity winEntity = _world.NewEntity();
                    winEntity.Get<WinTrackerComponent>();
                    DeleteStartGameEntities();

                }
            }
        }

        private void DeleteStartGameEntities()
        {
            foreach (var index in _isOnGameTrackerFilter)
            {
                _isOnGameTrackerFilter.GetEntity(index).Destroy();
            }
        }
    }
}
