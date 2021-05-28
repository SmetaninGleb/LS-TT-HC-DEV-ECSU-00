using Leopotam.Ecs;
using Components;
using UnityEngine;

namespace Systems
{
    class EnemyOnFinishGameSystem : IEcsRunSystem
    {
        EcsFilter<FinishGameTrackerComponent> _finishFilter;
        EcsFilter<EnemyComponent> _enemyFilter;

        public void Run()
        {
            if (!_finishFilter.IsEmpty())
            {
                foreach (var index in _enemyFilter)
                {
                    GameObject.Destroy(_enemyFilter.Get1(index).EnemyObject);
                    _enemyFilter.GetEntity(index).Destroy();
                }
            }
        }
    }
}
