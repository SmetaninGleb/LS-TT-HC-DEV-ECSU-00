using Components;
using Leopotam.Ecs;
using ScriptableObjects;
using UnityEngine;

namespace Systems
{
    class MakeExplosionSystem : IEcsRunSystem
    {
        private EcsFilter<ProjectileComponent, ExplosionComponent> _explosionFilter;
        private EcsFilter<EnemyComponent> _enemyFilter;
        private EcsFilter<ObstacleComponent> _obstacleFilter;

        public void Run()
        {
            foreach (var explosionIndex in _explosionFilter) {
                Vector3 projectilePosition = _explosionFilter.Get1(explosionIndex).ProjectileObject.transform.position;
                float explosionRadius = _explosionFilter.Get1(explosionIndex).ProjectileType.ExplosionRadius;
                foreach (var enemyIndex in _enemyFilter)
                {
                    EcsEntity enemyEntity = _enemyFilter.GetEntity(enemyIndex);
                    GameObject enemyObject = enemyEntity.Get<EnemyComponent>().EnemyObject;
                    float distance = (projectilePosition - enemyObject.transform.position).magnitude;
                    if (distance <= explosionRadius)
                    {
                        ref DamageComponent damageComponent = ref enemyEntity.Get<DamageComponent>();
                        damageComponent.Damage = _explosionFilter.Get1(explosionIndex).ProjectileType.Damage;
                        damageComponent.ExplosionPosition = projectilePosition;
                        damageComponent.ExplosionRadius = explosionRadius;
                    }
                }

                foreach (var index in _obstacleFilter)
                {
                    EcsEntity obstacleEntity = _obstacleFilter.GetEntity(index);
                    GameObject obstacleObject = obstacleEntity.Get<ObstacleComponent>().ObstacleObject;
                    float distance = (projectilePosition - obstacleObject.transform.position).magnitude;
                    if (distance <= explosionRadius)
                    {
                        ref ForcedObstacleComponent forceComponent = ref obstacleEntity.Get<ForcedObstacleComponent>();
                        forceComponent.ExplosinRaduis = explosionRadius;
                        forceComponent.ProjectilePosition = projectilePosition;
                        forceComponent.ProjectileMaxForce = _explosionFilter.Get1(explosionIndex).ProjectileType.MaxForceToObstacle;
                    }
                }
            }
        }
    }
}
