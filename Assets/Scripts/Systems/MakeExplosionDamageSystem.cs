using Components;
using Leopotam.Ecs;
using ScriptableObjects;
using UnityEngine;

namespace Systems
{
    class MakeExplosionDamageSystem : IEcsRunSystem
    {
        private EcsFilter<ProjectileComponent, ExplosionComponent> _explosionFilter;
        private EcsFilter<EnemyComponent> _enemyFilter;

        public void Run()
        {
            foreach (var explosionIndex in _explosionFilter) {
                Vector3 projectilePosition = _explosionFilter.Get1(explosionIndex).ProjectileObject.transform.position;
                float explosionRadius = _explosionFilter.Get1(explosionIndex).ProjectileType.ExplosionRadius;
                Collider[] overlapColliders = Physics.OverlapSphere(projectilePosition, explosionRadius);
                foreach (Collider collider in overlapColliders)
                {
                    GameObject overlapObject = collider.gameObject;
                    if (overlapObject.TryGetComponent(out EnemyMonoBehaviour enemy))
                    {
                        foreach (var enemyIndex in _enemyFilter)
                        {
                            EcsEntity enemyEntity = _enemyFilter.GetEntity(enemyIndex);
                            GameObject enemyObject = enemyEntity.Get<EnemyComponent>().EnemyObject;
                            if (overlapObject == enemyObject)
                            {
                                ProjectileType projectileType = _explosionFilter.Get1(explosionIndex).ProjectileType;
                                enemyEntity.Get<DamageComponent>().Damage = projectileType.Damage;
                            }
                        }
                    }
                }
            }
        }
    }
}
