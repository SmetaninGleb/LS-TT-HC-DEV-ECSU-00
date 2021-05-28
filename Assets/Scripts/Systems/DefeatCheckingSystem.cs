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
                DeleteIsOnGameTrackerComponent();
            }
        }

        private void DeleteIsOnGameTrackerComponent()
        {
            foreach (var index in _isOnGameTrackerFilter)
            {
                _isOnGameTrackerFilter.GetEntity(index).Destroy();
            }
        }
    }
}
