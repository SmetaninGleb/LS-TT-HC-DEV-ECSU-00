using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    class DefeatCheckingSystem : IEcsRunSystem
    {
        private EcsFilter<DefeatFieldComponent> _defeatFieldFilter;
        private EcsFilter<StartGameTrackerComponent> _startGameTrackerFilter;
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

            if (isDefeat)
            {
                EcsEntity defeatEntity = _world.NewEntity();
                defeatEntity.Get<DefeatTrackerComponent>();
                defeatEntity.Get<FinishGameTrackerComponent>();
                DeleteStartGameTrackerComponent();
            }
        }

        private void DeleteStartGameTrackerComponent()
        {
            foreach (var index in _startGameTrackerFilter)
            {
                _startGameTrackerFilter.GetEntity(index).Destroy();
            }
        }
    }
}
