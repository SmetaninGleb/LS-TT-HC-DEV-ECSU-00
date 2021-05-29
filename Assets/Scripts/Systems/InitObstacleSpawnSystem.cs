using Leopotam.Ecs;
using ScriptableObjects;
using UnityEngine;
using Components;

namespace Systems
{
    class InitObstacleSpawnSystem : IEcsRunSystem
    {

        private EcsFilter<BeforeStartTrackerComponent> _beforeStartFilter;
        private EcsFilter<ObstacleComponent> _obstacleFilter;
        private ObstacleTypesContainer _obstacleTypesContainer;
        private ObstacleSpawnConfiguration _obstacleSpawnConfiguration;
        private FieldConfiguration _fieldConfiguration;
        private GameConfiguration _gameConfiguration;
        private DefeatFieldConfiguration _defeatFieldConfiguration;
        private EcsWorld _world;

        public void Run()
        {
            if (!_beforeStartFilter.IsEmpty() && _obstacleFilter.IsEmpty())
            {
                float minX = _gameConfiguration.StartGamePosition.x + _fieldConfiguration.StartFieldPosition.x + _defeatFieldConfiguration.DefeatFieldLength + _obstacleSpawnConfiguration.XBottomPadding;
                float maxX = _gameConfiguration.StartGamePosition.x + _fieldConfiguration.StartFieldPosition.x + _defeatFieldConfiguration.DefeatFieldLength + _fieldConfiguration.FieldBoundaries().x - _obstacleSpawnConfiguration.XTopPadding;
                float floorY = _gameConfiguration.StartGamePosition.y + _fieldConfiguration.StartFieldPosition.y + _fieldConfiguration.FieldBoundaries().y;
                float minZ = _gameConfiguration.StartGamePosition.z + _fieldConfiguration.StartFieldPosition.z - _fieldConfiguration.FieldBoundaries().z / 2f + _obstacleSpawnConfiguration.ZPadding;
                float maxZ = _gameConfiguration.StartGamePosition.z + _fieldConfiguration.StartFieldPosition.z + _fieldConfiguration.FieldBoundaries().z / 2f - _obstacleSpawnConfiguration.ZPadding;

                Debug.DrawLine(new Vector3(minX, floorY, minZ), new Vector3(maxX, floorY, maxZ), Color.white, 100f, false);

                foreach (ObstacleType obstacleType in _obstacleTypesContainer.ObstacleTypes)
                {
                    for (int i = 0; i < obstacleType.NumberOfObstacles; i++)
                    {
                        float xCoordinate = Random.Range(minX, maxX);
                        float zCoordinate = Random.Range(minZ, maxZ);
                        float yCoordinate = floorY + obstacleType.SpawnHeight;

                        GameObject obstacleObject = GameObject.Instantiate(obstacleType.ObstacleObject, new Vector3(xCoordinate, yCoordinate, zCoordinate), Quaternion.identity);
                        EcsEntity obstacleEntity = _world.NewEntity();
                        ref ObstacleComponent obstacleComponent = ref obstacleEntity.Get<ObstacleComponent>();
                        obstacleComponent.ObstacleObject = obstacleObject;
                        obstacleComponent.ObstacleType = obstacleType;
                    }
                }
            }
        }
    }
}
