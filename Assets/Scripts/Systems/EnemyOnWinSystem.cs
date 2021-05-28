using Leopotam.Ecs;
using Components;
using UnityEngine;

namespace Systems
{
    class EnemyOnWinSystem : IEcsRunSystem
    {
        EcsFilter<EnemyComponent>.Exclude<EnemyLooseComponent> _enemyFilter;
        EcsFilter<WinTrackerComponent> _winFilter;


        public void Run()
        {
            if (!_winFilter.IsEmpty()) {
                foreach (var index in _enemyFilter)
                {
                    _enemyFilter.GetEntity(index).Get<EnemyLooseComponent>();
                }
            }
        }
    }
}
