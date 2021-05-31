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
        private DefeatFieldConfiguration _defeatFieldConfiguration;
        private EcsWorld _world;

        public void Init()
        {
            foreach(var spawner in _spawnerContainer.Spawners)
            {
                Vector3 position = _gameConfiguration.StartGamePosition + Vector3.right * _defeatFieldConfiguration.DefeatFieldLength + Vector3.right * _fieldConfiguration.FieldLength + spawner.Position;
                GameObject spawnerObject = GameObject.Instantiate(spawner.SpawnerType.SpawnerObject, position, Quaternion.identity);
                EcsEntity spawnerEntity = _world.NewEntity();
                ref SpawnerComponent spawnerComponent = ref spawnerEntity.Get<SpawnerComponent>();
                spawnerComponent.SpawnerObject = spawnerObject;
                spawnerComponent.SpawnerType = spawner.SpawnerType;
            }
        }
    }
}
