using Components;
using Leopotam.Ecs;
using ScriptableObjects;
using UnityEngine;

namespace Systems
{
    class CreatingSpawnersSystem : IEcsInitSystem
    {
        private GameConfiguration _gameConfiguration;
        private SpawnerContainer _spawnerContainer;
        private FieldConfiguration _fieldConfiguration;
        private EcsWorld _world;

        public void Init()
        {
            foreach(var spawner in _spawnerContainer.Spawners)
            {
                GameObject spawnerObject = GameObject.Instantiate(spawner.SpawnerType.SpawnerObject, _gameConfiguration.StartGamePosition + Vector3.right * _fieldConfiguration.FieldLength + spawner.Position, Quaternion.identity);
                EcsEntity spawnerEntity = _world.NewEntity();
                ref SpawnerComponent spawnerComponent = ref spawnerEntity.Get<SpawnerComponent>();
                spawnerComponent.SpawnerObject = spawnerObject;
                spawnerComponent.SpawnerType = spawner.SpawnerType;
            }
        }
    }
}
