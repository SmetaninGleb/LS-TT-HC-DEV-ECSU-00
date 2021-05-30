using Leopotam.Ecs;
using ScriptableObjects;
using UnityEngine;
using Components;
using UnityEngine.AI;

namespace Systems
{
    class InitializeNavMeshSystem : IEcsInitSystem
    {
        private NavMeshConfiguration _navMeshConfiguration;
        private EcsWorld _world;

        public void Init()
        {
            GameObject navMeshObject = GameObject.Instantiate(_navMeshConfiguration.NavMesh);
            NavMeshSurface navMeshUnityComponent = navMeshObject.GetComponent<NavMeshSurface>();
            int ignoreLayer = LayerMask.GetMask(_navMeshConfiguration.IgnoreLayerName);
            int navLayerMask = ~0 - ignoreLayer;
            navMeshUnityComponent.layerMask = navLayerMask; 
            navMeshUnityComponent.BuildNavMesh();
            EcsEntity navMeshEntity = _world.NewEntity();
            ref NavMeshComponent navMeshComponent = ref navMeshEntity.Get<NavMeshComponent>();
            navMeshComponent.NavMeshObject = navMeshObject;
            navMeshComponent.NavMeshUnityComponent = navMeshUnityComponent;
        }
    }
}
