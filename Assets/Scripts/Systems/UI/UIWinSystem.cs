using Leopotam.Ecs;
using Components;
using ScriptableObjects;
using UnityEngine;
using MonoBehaviours;

namespace Systems
{
    class UIWinSystem : IEcsRunSystem
    {
        private EcsFilter<WinTrackerComponent> _winFilter;
        private EcsFilter<UIWinComponent> _uiWinFilter;
        private EcsFilter<CanvasComponent> _canvasFilter;
        private UIConfiguration _uiConfig;
        private EcsWorld _world;

        public void Run()
        {
            if (!_winFilter.IsEmpty())
            {
                bool isNextGameTapped = false;

                if (_uiWinFilter.IsEmpty())
                {
                    GameObject canvasObject = _canvasFilter.Get1(0).CanvasObject;
                    GameObject winObject = GameObject.Instantiate(_uiConfig.Win, canvasObject.transform);
                    EcsEntity uiWinEntity = _world.NewEntity();
                    uiWinEntity.Get<UIWinComponent>().WinObject = winObject;
                    isNextGameTapped = winObject.GetComponent<UIWinMonoBehaviour>().IsNextGameTapped;
                } else
                {
                    isNextGameTapped = _uiWinFilter.Get1(0).WinObject.GetComponent<UIWinMonoBehaviour>().IsNextGameTapped;
                }

                if (isNextGameTapped)
                {
                    DeleteAllEntitiesInFilter(_winFilter);
                    DeleteUIWinObjects();
                    DeleteAllEntitiesInFilter(_uiWinFilter);
                    EcsEntity finishGameEntity = _world.NewEntity();
                    finishGameEntity.Get<FinishGameTrackerComponent>();
                }
            }
        }

        private void DeleteAllEntitiesInFilter(EcsFilter filter)
        {
            foreach (var index in filter)
            {
                filter.GetEntity(index).Destroy();
            }
        }

        private void DeleteUIWinObjects()
        {
            foreach (var index in _uiWinFilter)
            {
                GameObject.Destroy(_uiWinFilter.Get1(index).WinObject);
            }
        }
    }
}
