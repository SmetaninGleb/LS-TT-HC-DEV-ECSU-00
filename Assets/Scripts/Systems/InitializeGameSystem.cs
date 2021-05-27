using Leopotam.Ecs;
using Components;
using ScriptableObjects;
using UnityEngine;

namespace Systems
{
    class InitializeGameSystem : IEcsInitSystem
    {
        private UIConfiguration _uIConfiguration;
        private EcsWorld _world;

        public void Init()
        {
            EcsEntity beforeGameEntity = _world.NewEntity();
            beforeGameEntity.Get<BeforeStartTrackerComponent>();
            GameObject canvasObject = GameObject.Instantiate(_uIConfiguration.Canvas);
            EcsEntity canvasEntity = _world.NewEntity();
            canvasEntity.Get<CanvasComponent>().CanvasObject = canvasObject;
        }
    }
}
