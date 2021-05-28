using Leopotam.Ecs;
using Components;
using ScriptableObjects;
using UnityEngine;
using MonoBehaviours;

namespace Systems
{
    class UIOnGameSystem : IEcsRunSystem
    {
        private EcsFilter<IsOnGameTrackerComponent> _isOnGameFilter;
        private EcsFilter<UIOnGameComponent> _uiOnGameFilter;
        private EcsFilter<CanvasComponent> _canvasFilter;
        private UIConfiguration _uiConfiguration;
        private GameConfiguration _gameConfiguration;
        private EcsWorld _world;

        public void Run()
        {
            if (!_isOnGameFilter.IsEmpty())
            {
                GameObject uiOnGameObject;
                if (_uiOnGameFilter.IsEmpty())
                {
                    GameObject canvasObject = _canvasFilter.Get1(0).CanvasObject;
                    uiOnGameObject = GameObject.Instantiate(_uiConfiguration.OnGame, canvasObject.transform);
                    uiOnGameObject.GetComponent<UIOnGameMonoBehaviour>().MinValue = 0;
                    uiOnGameObject.GetComponent<UIOnGameMonoBehaviour>().MaxValue = _gameConfiguration.TimeToWin;
                    EcsEntity uiOnGameEntity = _world.NewEntity();
                    uiOnGameEntity.Get<UIOnGameComponent>().OnGameObject = uiOnGameObject;
                } else
                {
                    uiOnGameObject = _uiOnGameFilter.Get1(0).OnGameObject;
                }
                float TimeToShow = _gameConfiguration.TimeToWin - (Time.timeSinceLevelLoad - _isOnGameFilter.Get1(0).StartTime);
                uiOnGameObject.GetComponent<UIOnGameMonoBehaviour>().TimeSecondsToShow = TimeToShow;
            } else
            {
                foreach (var index in _uiOnGameFilter)
                {
                    GameObject.Destroy(_uiOnGameFilter.Get1(index).OnGameObject);
                    _uiOnGameFilter.GetEntity(index).Destroy();
                }
            }
        }
    }
}
