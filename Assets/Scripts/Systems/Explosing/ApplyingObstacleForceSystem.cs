using Leopotam.Ecs;
using Components;
using UnityEngine;

namespace Systems
{
    class ApplyingObstacleForceSystem : IEcsRunSystem
    {
        EcsFilter<ObstacleComponent, ForcedObstacleComponent> _forcedFilter;

        public void Run()
        {
            foreach (var index in _forcedFilter)
            {
                EcsEntity obstacleEntity = _forcedFilter.GetEntity(index);
                GameObject obstacleObject = _forcedFilter.Get1(index).ObstacleObject;
                ref ForcedObstacleComponent forcedComponent = ref _forcedFilter.Get2(index);
                Vector3 projectilePosition = forcedComponent.ProjectilePosition;
                Rigidbody obstacleRigitBody = obstacleObject.GetComponent<Rigidbody>();
                Vector3 force = (obstacleObject.transform.position - projectilePosition);
                float distance = force.magnitude;
                force = Vector3.Normalize(force);
                float range = 1f - distance / forcedComponent.ExplosinRaduis;
                float forceMultiplier = Mathf.Lerp(0, forcedComponent.ProjectileMaxForce, range);
                force = force * forceMultiplier;
                obstacleRigitBody.AddForce(force, ForceMode.Impulse);
                obstacleEntity.Del<ForcedObstacleComponent>();
            }
        }
    }
}
