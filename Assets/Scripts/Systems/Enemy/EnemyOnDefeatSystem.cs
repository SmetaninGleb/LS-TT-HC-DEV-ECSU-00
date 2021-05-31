using Components;
using Leopotam.Ecs;

namespace Systems
{
    class EnemyOnDefeatSystem : IEcsRunSystem
    {
        EcsFilter<EnemyComponent>.Exclude<EnemyWinComponent> _enemyFilter;
        EcsFilter<DefeatTrackerComponent> _defeatFilter;

        public void Run()
        {
            if (!_defeatFilter.IsEmpty())
            {
                foreach (var index in _enemyFilter)
                {
                    _enemyFilter.GetEntity(index).Get<EnemyWinComponent>();
                }
            }
        }
    }
}
