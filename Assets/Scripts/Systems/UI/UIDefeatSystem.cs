using Leopotam.Ecs;
using ScriptableObjects;
using Components;
using UnityEngine;
using MonoBehaviours;

namespace Systems
{
    class UIDefeatSystem : IEcsRunSystem
    {
        private EcsFilter<DefeatTrackerComponent> _defeatTrackerFilter;
        private EcsFilter<UIDefeatComponent> _uiDefeatFilter;
        private EcsFilter<CanvasComponent> _canvasFilter;
        private UIConfiguration _uiConfiguration;
        private EcsWorld _world;

        public void Run()
        {
            if (!_defeatTrackerFilter.IsEmpty())
            {
                bool isNextGameTapped = false;

                if (_uiDefeatFilter.IsEmpty())
                {
                    GameObject canvasObject = _canvasFilter.Get1(0).CanvasObject;
                    GameObject defeatObject = GameObject.Instantiate(_uiConfiguration.Defeat, canvasObject.transform);
                    EcsEntity uiDefeatEntity = _world.NewEntity();
                    uiDefeatEntity.Get<UIDefeatComponent>().DefeatObject = defeatObject;
                    isNextGameTapped = defeatObject.GetComponent<UIDefeatMonoBehaviour>().IsNextGameTapped;
                } else
                {
                    isNextGameTapped = _uiDefeatFilter.Get1(0).DefeatObject.GetComponent<UIDefeatMonoBehaviour>().IsNextGameTapped;
                }

                if (isNextGameTapped)
                {
                    DeleteAllEntitiesInFilter(_defeatTrackerFilter);
                    DeleteUIDefeatObjects();
                    DeleteAllEntitiesInFilter(_uiDefeatFilter);
                    EcsEntity finishEntity = _world.NewEntity();
                    finishEntity.Get<FinishGameTrackerComponent>();
                }
            }
        }

        private void DeleteAllEntitiesInFilter (EcsFilter filter)
        {
            foreach (var index in filter)
            {
                filter.GetEntity(index).Destroy();
            }
        }

        private void DeleteUIDefeatObjects()
        {
            foreach (var index in _uiDefeatFilter)
            {
                GameObject.Destroy(_uiDefeatFilter.Get1(index).DefeatObject);
            }
        }
    }
}
