using Components;
using Leopotam.Ecs;
using ScriptableObjects;
using UnityEngine;

namespace Systems
{
    class ApplyingDamageSystem : IEcsRunSystem
    {
        private EcsFilter<EnemyComponent, DamageComponent> _damageFilter;

        public void Run()
        {
            foreach (var index in _damageFilter)
            {
                GameObject enemyObject = _damageFilter.Get1(index).EnemyObject;
                ref DamageComponent damageComponent = ref _damageFilter.Get2(index);
                float explosionRadius = damageComponent.ExplosionRadius;
                int damage = damageComponent.Damage;
                Vector3 explosionPosition = damageComponent.ExplosionPosition;
                float distance = (explosionPosition - enemyObject.transform.position).magnitude;
                float rangeDistance = 1f - distance / explosionRadius;
                damage = (int)Mathf.Lerp(0f, (float)damage, rangeDistance);
                enemyObject.GetComponent<EnemyMonoBehaviour>().Health -= damage;
                _damageFilter.GetEntity(index).Del<DamageComponent>();
            }
        }
    }
}
