using Components;
using Leopotam.Ecs;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.AI;

namespace Systems
{
    class MoveEnemySystem : IEcsRunSystem
    {
        private EcsFilter<EnemyComponent> _enemyFilter;
        private EcsFilter<IsOnGameTrackerComponent> _isOnGameFilter;
        private EcsFilter<DefeatFieldComponent> _defeatFieldFilter;

        public void Run()
        {
            if (!_isOnGameFilter.IsEmpty())
            {
                foreach (var index in _enemyFilter)
                {
                    ref EnemyComponent enemyComponent = ref _enemyFilter.GetEntity(index).Get<EnemyComponent>();
                    GameObject enemyObject = enemyComponent.EnemyObject;
                    EnemyType enemyType = enemyComponent.EnemyType;
                    NavMeshAgent enemyNavMeshAgent = enemyComponent.EnemyNavMeshAgent;
                    //enemyObject.transform.Translate(Vector3.left * enemyType.EnemySpeed * Time.deltaTime);
                    Vector3 defeatFieldPosition = _defeatFieldFilter.Get1(0).DefeatFieldObject.transform.position;
                    Vector3 destinationPosition = new Vector3(defeatFieldPosition.x, defeatFieldPosition.y, enemyObject.transform.position.z);
                    enemyNavMeshAgent.SetDestination(destinationPosition);
                }
            } else
            {
                foreach (var index in _enemyFilter)
                {
                    ref EnemyComponent enemyComponent = ref _enemyFilter.Get1(index);
                    Vector3 enemyPosition = enemyComponent.EnemyObject.transform.position;
                    NavMeshAgent enemyNavMeshAgent = enemyComponent.EnemyNavMeshAgent;
                    enemyNavMeshAgent.SetDestination(enemyPosition);
                }
            }
        }
    }
}
