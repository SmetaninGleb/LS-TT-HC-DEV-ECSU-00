using Leopotam.Ecs;
using ScriptableObjects;
using UnityEngine;
using Components;

namespace Systems
{
    class WinCheckingSystem : IEcsRunSystem
    {
        private EcsFilter<WinTrackerComponent> _winFilter;
        private EcsFilter<StartGameTrackerComponent> _startGameFilter;
        private GameConfiguration _gameConfigurations;
        private EcsWorld _world;

        public void Run()
        {
            if (_winFilter.IsEmpty() && Time.timeSinceLevelLoad - _startGameFilter.Get1(0).StartTime > _gameConfigurations.TimeToWin)
            {
                EcsEntity winEntity = _world.NewEntity();
                winEntity.Get<WinTrackerComponent>();
                winEntity.Get<FinishGameTrackerComponent>();
                DeleteStartGameEntities();
                
            }
        }

        private void DeleteStartGameEntities()
        {
            foreach (var index in _startGameFilter)
            {
                _startGameFilter.GetEntity(index).Destroy();
            }
        }
    }
}
