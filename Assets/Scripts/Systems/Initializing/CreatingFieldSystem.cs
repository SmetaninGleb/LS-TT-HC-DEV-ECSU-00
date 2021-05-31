using Components;
using Leopotam.Ecs;
using ScriptableObjects;
using UnityEngine;

namespace Systems
{
    class CreatingFieldSystem : IEcsInitSystem
    {
        private FieldConfiguration _fieldConfiguration;
        private GameConfiguration _gameConfiguration;
        private DefeatFieldConfiguration _defeatFieldConfiguration;
        private EcsWorld _world;

        public void Init()
        {
            EcsEntity field = _world.NewEntity();
            Vector3 position = _gameConfiguration.StartGamePosition + _defeatFieldConfiguration.Position + Vector3.right * _defeatFieldConfiguration.DefeatFieldLength + _fieldConfiguration.StartFieldPosition + Vector3.right * _fieldConfiguration.FieldLength / 2f;
            GameObject fieldObject = GameObject.Instantiate(_fieldConfiguration.GameField, position, Quaternion.identity);
            field.Get<FieldViewComponent>().FieldObject = fieldObject;
        }
    }
}