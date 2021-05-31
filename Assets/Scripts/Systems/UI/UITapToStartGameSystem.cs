using Leopotam.Ecs;
using Components;
using ScriptableObjects;
using MonoBehaviours;
using UnityEngine;

namespace Systems
{
    class UITapToStartGameSystem : IEcsRunSystem
    {
        private EcsFilter<BeforeStartTrackerComponent> _beforeStartFilter;
        private EcsFilter<FinishGameTrackerComponent> _finishFilter;
        private EcsFilter<CanvasComponent> _canvasFilter;
        private EcsFilter<UITapToStartComponent> _tapToStartFilter;
        private UIConfiguration _uiConfiguration;
        private EcsWorld _world;

        public void Run()
        {
            if (!_beforeStartFilter.IsEmpty() && _finishFilter.IsEmpty())
            {
                bool isTapped = false;
                if (_tapToStartFilter.IsEmpty())
                {
                    GameObject canvasObject = _canvasFilter.Get1(0).CanvasObject;
                    GameObject tapToStartObject = GameObject.Instantiate(_uiConfiguration.TapToStart, canvasObject.transform);
                    EcsEntity tapToStartEntity = _world.NewEntity();
                    tapToStartEntity.Get<UITapToStartComponent>().TapToStartObject = tapToStartObject;
                    isTapped = tapToStartObject.GetComponent<UITapToStartMonoBehaviour>().IsTapped;
                }
                else
                {
                    isTapped = _tapToStartFilter.Get1(0).TapToStartObject.GetComponent<UITapToStartMonoBehaviour>().IsTapped;
                }

                if (isTapped)
                {
                    EcsEntity startGameEntity = _world.NewEntity();
                    startGameEntity.Get<StartGameComponent>();
                    DeleteTapToStartEntities();
                }

            }
        }

        private void DeleteTapToStartEntities()
        {
            foreach(var index in _tapToStartFilter)
            {
                GameObject.Destroy(_tapToStartFilter.Get1(index).TapToStartObject);
                _tapToStartFilter.GetEntity(index).Destroy();
            }
        }
    }
}
