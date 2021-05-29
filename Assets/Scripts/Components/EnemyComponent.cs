using ScriptableObjects;
using UnityEngine;
using UnityEngine.AI;

namespace Components
{
    struct EnemyComponent
    {
        public EnemyType EnemyType;
        public GameObject EnemyObject;
        public NavMeshAgent EnemyNavMeshAgent;
    }
}
