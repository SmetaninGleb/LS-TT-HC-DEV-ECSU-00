using Leopotam.Ecs;
using Components;
using UnityEngine;

namespace Systems
{
    class ObstacleOnFinishSystem : IEcsRunSystem
    {
        EcsFilter<FinishGameTrackerComponent> _finishFilter;
        EcsFilter<ObstacleComponent> _obstacleFilter;

        public void Run()
        {
            if (!_finishFilter.IsEmpty())
            {
                foreach (var index in _obstacleFilter)
                {
                    GameObject.Destroy(_obstacleFilter.Get1(index).ObstacleObject);
                    _obstacleFilter.GetEntity(index).Destroy();
                }
            }
        }
    }
}
