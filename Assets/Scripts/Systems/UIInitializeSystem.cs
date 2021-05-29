using Leopotam.Ecs;
using Components;
using UnityEngine;
using ScriptableObjects;

namespace Systems
{
    class UIInitializeSystem : IEcsInitSystem
    {
        private EcsFilter<FieldViewComponent> _fieldFilter;
        private UIConfiguration _uIConfiguration;
        private EcsWorld _world;

        public void Init()
        {
            GameObject canvasObject = GameObject.Instantiate(_uIConfiguration.Canvas);
            Camera camera =_fieldFilter.Get1(0).FieldObject.GetComponentInChildren<Camera>();
            Canvas canvasUnityComponent = canvasObject.GetComponent<Canvas>();
            canvasUnityComponent.worldCamera = camera;
            canvasUnityComponent.planeDistance = _uIConfiguration.PlaneDistanceCameraCanvas;
            EcsEntity canvasEntity = _world.NewEntity();
            canvasEntity.Get<CanvasComponent>().CanvasObject = canvasObject;
        }
    }
}
