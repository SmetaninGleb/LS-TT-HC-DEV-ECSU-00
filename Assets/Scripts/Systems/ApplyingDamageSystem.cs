using Components;
using Leopotam.Ecs;
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
                int damage = _damageFilter.Get2(index).Damage;
                enemyObject.GetComponent<EnemyMonoBehaviour>().Health -= damage;
                _damageFilter.GetEntity(index).Del<DamageComponent>();
            }
        }
    }
}
