using Leopotam.Ecs;
using Components;
using UnityEngine;
using ScriptableObjects;

namespace Systems
{
    class UIInitializeSystem : IEcsInitSystem
    {
        private UIConfiguration _uIConfiguration;
        private EcsWorld _world;

        public void Init()
        {
            GameObject canvasObject = GameObject.Instantiate(_uIConfiguration.Canvas);
            EcsEntity canvasEntity = _world.NewEntity();
            canvasEntity.Get<CanvasComponent>().CanvasObject = canvasObject;
        }
    }
}
