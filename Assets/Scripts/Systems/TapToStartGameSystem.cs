using Leopotam.Ecs;
using Components;
using ScriptableObjects;
using MonoBehaviours;
using UnityEngine;

namespace Systems
{
    class TapToStartGameSystem : IEcsRunSystem
    {
        private EcsFilter<BeforeStartTrackerComponent> _beforeStartFilter;
        private EcsFilter<FinishGameTrackerComponent> _finishFilter;
        private EcsFilter<CanvasComponent> _canvasFilter;
        private EcsFilter<TapToStartComponent> _tapToStartFilter;
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
                    tapToStartEntity.Get<TapToStartComponent>().TapToStartObject = tapToStartObject;
                    isTapped = tapToStartObject.GetComponent<TapToStartMonoBehaviour>().IsTapped;
                }
                else
                {
                    isTapped = _tapToStartFilter.Get1(0).TapToStartObject.GetComponent<TapToStartMonoBehaviour>().IsTapped;
                }

                if (isTapped)
                {
                    DeleteBeforeStartEntities();
                    EcsEntity startGameEntity = _world.NewEntity();
                    startGameEntity.Get<StartGameTrackerComponent>().StartTime = Time.timeSinceLevelLoad;
                    DeleteTapToStartEntities();
                }

            }
        }

        private void DeleteTapToStartEntities()
        {
            foreach(var index in _tapToStartFilter)
            {
                _tapToStartFilter.GetEntity(index).Destroy();
            }
        }

        private void DeleteBeforeStartEntities()
        {
            foreach (int index in _beforeStartFilter)
            {
                _beforeStartFilter.GetEntity(index).Destroy();
            }
        }
    }
}
