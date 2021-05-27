using Components;
using Leopotam.Ecs;
using ScriptableObjects;
using UnityEngine;

namespace Systems
{
    class MoveEnemySystem : IEcsRunSystem
    {
        private EcsFilter<EnemyComponent> _enemyFilter;
        private EcsFilter<StartGameTrackerComponent> _startFilter;

        public void Run()
        {
            if (!_startFilter.IsEmpty())
            {
                foreach (var index in _enemyFilter)
                {
                    GameObject enemyObject = _enemyFilter.Get1(index).EnemyObject;
                    EnemyType enemyType = _enemyFilter.Get1(index).EnemyType;
                    enemyObject.transform.Translate(Vector3.left * enemyType.EnemySpeed * Time.deltaTime);
                }
            }
        }
    }
}
