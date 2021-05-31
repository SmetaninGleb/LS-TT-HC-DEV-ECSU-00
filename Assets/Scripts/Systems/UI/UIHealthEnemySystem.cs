using System;
using Leopotam.Ecs;
using UnityEngine;
using Components;
using MonoBehaviours;
using ScriptableObjects;

namespace Systems
{
    class UIHealthEnemySystem : IEcsRunSystem
    {
        private EcsFilter<EnemyComponent> _enemyFilter;
        private EcsFilter<EnemyComponent>.Exclude<UIEnemyInitComponent> _enemyWhithoutUIInitFilter;
        private EcsFilter<FieldViewComponent> _fieldFilter;


        public void Run()
        {
            foreach (var index in _enemyWhithoutUIInitFilter)
            {
                EcsEntity enemyEntity = _enemyWhithoutUIInitFilter.GetEntity(index);
                GameObject enemyObject = enemyEntity.Get<EnemyComponent>().EnemyObject;
                EnemyType enemyType = enemyEntity.Get<EnemyComponent>().EnemyType;
                UIEnemyHealthMonoBehaviour uiHealthMono = enemyObject.GetComponentInChildren<UIEnemyHealthMonoBehaviour>();
                uiHealthMono.MinValue = 0;
                uiHealthMono.MaxValue = enemyType.HealthPoints;
                enemyEntity.Get<UIEnemyInitComponent>();
            }

            foreach (var index in _enemyFilter)
            {
                GameObject enemyObject = _enemyFilter.Get1(index).EnemyObject;
                int health = enemyObject.GetComponent<EnemyMonoBehaviour>().Health;
                enemyObject.GetComponentInChildren<UIEnemyHealthMonoBehaviour>().HealthValue = health;
            }
        }
    }
}
