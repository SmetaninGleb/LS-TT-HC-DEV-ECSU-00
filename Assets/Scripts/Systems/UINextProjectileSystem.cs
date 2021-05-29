﻿using Leopotam.Ecs;
using UnityEngine;
using Components;
using ScriptableObjects;

namespace Systems
{
    class UINextProjectileSystem : IEcsRunSystem
    {
        private EcsFilter<NextProjectileComponent> _nextProjectileFilter;
        private EcsFilter<CanvasComponent> _canvasFilter;
        private EcsFilter<UIProjectileComponent> _uiProjectileFilter;
        private EcsFilter<IsOnGameTrackerComponent> _isOnGameFilter;
        private UIConfiguration _uiConfiguration;
        private EcsWorld _world;

        public void Run()
        {
            if (!_isOnGameFilter.IsEmpty())
            {
                Transform canvasTransform = _canvasFilter.Get1(0).CanvasObject.transform;
                Vector3 canvasPosition = canvasTransform.position;
                Vector3 uiProjectilePosition = canvasPosition + _uiConfiguration.UIPrijectileCoordinates;
                GameObject nextProjectileUIObject = _nextProjectileFilter.Get1(0).ProjectileType.UIProjectileObject;
                if (_uiProjectileFilter.IsEmpty())
                {
                    EcsEntity uiProjectileEntity = _world.NewEntity();
                    GameObject nextInstProjectileUIObject = GameObject.Instantiate(nextProjectileUIObject, canvasTransform);
                    nextInstProjectileUIObject.transform.localPosition = _uiConfiguration.UIPrijectileCoordinates;
                    uiProjectileEntity.Get<UIProjectileComponent>().UIProjectileObject = nextInstProjectileUIObject;
                }
                else
                {
                    GameObject currentProjectileUIObject = _uiProjectileFilter.Get1(0).UIProjectileObject;
                    if (currentProjectileUIObject != nextProjectileUIObject)
                    {
                        GameObject.Destroy(currentProjectileUIObject);
                        GameObject nextInstProjectileUIObject = GameObject.Instantiate(nextProjectileUIObject, canvasTransform);
                        nextInstProjectileUIObject.transform.localPosition = _uiConfiguration.UIPrijectileCoordinates;
                        _uiProjectileFilter.Get1(0).UIProjectileObject = nextInstProjectileUIObject;
                    }
                }
            } else
            {
                foreach (var index in _uiProjectileFilter)
                {
                    GameObject.Destroy(_uiProjectileFilter.Get1(index).UIProjectileObject);
                    _uiProjectileFilter.GetEntity(index).Destroy();
                }
            }
        }
    }
}
