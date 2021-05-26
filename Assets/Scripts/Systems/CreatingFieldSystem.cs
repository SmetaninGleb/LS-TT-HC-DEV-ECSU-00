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
        private EcsWorld _world;

        public void Init()
        {
            EcsEntity field = _world.NewEntity();
            Debug.Log(_fieldConfiguration.FieldLength);
            GameObject fieldObject = GameObject.Instantiate(_fieldConfiguration.GameField, _gameConfiguration.StartGamePosition + _fieldConfiguration.StartFieldPosition + Vector3.right * _fieldConfiguration.FieldLength / 2f, Quaternion.identity);
            field.Get<FieldViewComponent>().FieldObject = fieldObject;
        }
    }
}