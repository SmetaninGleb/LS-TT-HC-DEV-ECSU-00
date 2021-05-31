using Leopotam.Ecs;
using Components;
using ScriptableObjects;
using UnityEngine;

namespace Systems
{
    class InitializeGameSystem : IEcsInitSystem
    {
        private EcsWorld _world;

        public void Init()
        {
            EcsEntity beforeGameEntity = _world.NewEntity();
            beforeGameEntity.Get<BeforeStartTrackerComponent>();
        }
    }
}
