using Components;
using Leopotam.Ecs;
using ScriptableObjects;
using UnityEngine;

namespace Systems
{
    class CreatingDefeatFieldSystem : IEcsInitSystem
    {
        private DefeatFieldConfiguration _defeatFieldConfiguration;
        private GameConfiguration _gameConfiguration;
        private EcsWorld _world;

        public void Init()
        {
            Vector3 position = _gameConfiguration.StartGamePosition + _defeatFieldConfiguration.Position + Vector3.right * _defeatFieldConfiguration.DefeatFieldLength / 2f;
            GameObject defeatFieldObject = GameObject.Instantiate(_defeatFieldConfiguration.DefeatField, position, Quaternion.identity);
            EcsEntity defeatFieldEntity = _world.NewEntity();
            defeatFieldEntity.Get<DefeatFieldComponent>().DefeatFieldObject = defeatFieldObject;
        }
    }
}
