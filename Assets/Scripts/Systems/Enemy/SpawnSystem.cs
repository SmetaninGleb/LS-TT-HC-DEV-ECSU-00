using Components;
using Leopotam.Ecs;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.AI;

namespace Systems
{
    class SpawnSystem : IEcsRunSystem
    {
        private EcsFilter<SpawnTimeTrackerComponent> _spawnTimeTrackerFilter;
        private EcsFilter<SpawnerComponent> _spawnerFilter;
        private EcsFilter<IsOnGameTrackerComponent> _isOnGameTrackerFilter;
        private EcsFilter<EndTimeTrackerComponent> _endTimeTrackerFilter;

        private SpawnConfiguration _spawnConfiguration;
        private EnemyTypesContainer _enemyTypesContainer;
        private GameConfiguration _gameConfiguration;
        private FieldConfiguration _fieldConfiguration;
        private EcsWorld _world;


        public void Run()
        {
            if (!_isOnGameTrackerFilter.IsEmpty() && _endTimeTrackerFilter.IsEmpty())
            {
                float currentTime = Time.timeSinceLevelLoad;
                ref float lastSpawnTime = ref _spawnTimeTrackerFilter.Get1(0).LastSpawnTime;

                if (IsTimeToSpawn(ref currentTime, ref lastSpawnTime))
                {
                    lastSpawnTime = Time.timeSinceLevelLoad;
                    Spawn();
                }
            }
        }

        private bool IsTimeToSpawn(ref float currentTime, ref float lastSpawnTime)
        {
            return currentTime - lastSpawnTime >= _spawnConfiguration.SpawnTimeRange;
        }

        private void Spawn()
        {
            int randomSpawnerIndex = Random.Range(0, _spawnerFilter.GetEntitiesCount());
            Vector3 spawnPosition = _spawnerFilter.Get1(randomSpawnerIndex).SpawnerObject.transform.position;
            int randomEnemyTypeIndex = Random.Range(0, _enemyTypesContainer.EnemyTypes.Length);
            EnemyType newEnemyType = _enemyTypesContainer.EnemyTypes[randomEnemyTypeIndex];
            GameObject newEnemyObject = GameObject.Instantiate(
                newEnemyType.EnemyObject,
                spawnPosition,
                Quaternion.Euler(0f, -90f, 0f));
            newEnemyObject.GetComponent<EnemyMonoBehaviour>().Health = newEnemyType.HealthPoints;
            EcsEntity newEnemy = _world.NewEntity();
            ref EnemyComponent enemyComponent = ref newEnemy.Get<EnemyComponent>();
            enemyComponent.EnemyObject = newEnemyObject;
            enemyComponent.EnemyType = newEnemyType;
            enemyComponent.EnemyNavMeshAgent = newEnemyObject.GetComponent<NavMeshAgent>();
            enemyComponent.EnemyNavMeshAgent.speed = newEnemyType.EnemySpeed;
        }
    }
}
