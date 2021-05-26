using Components;
using Leopotam.Ecs;
using ScriptableObjects;
using UnityEngine;

namespace Systems
{
    class MoveEnemySystem : IEcsRunSystem
    {
        EcsFilter<EnemyComponent> _enemyFilter;

        public void Run()
        {
            foreach(var index in _enemyFilter)
            {
                GameObject enemyObject = _enemyFilter.Get1(index).enemyObject;
                EnemyType enemyType = _enemyFilter.Get1(index).enemyType;
                enemyObject.transform.Translate(Vector3.left * enemyType.EnemySpeed * Time.deltaTime);
            }
        }
    }
}
