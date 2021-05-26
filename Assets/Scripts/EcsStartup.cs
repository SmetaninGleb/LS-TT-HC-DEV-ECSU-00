using Leopotam.Ecs;
using UnityEngine;
using ScriptableObjects;
using Systems;

namespace Client {
    sealed class EcsStartup : MonoBehaviour {
        EcsWorld _world;
        EcsSystems _systems;

        public GameConfiguration gameConfiguration;
        public FieldConfiguration fieldConfiguration;
        public SpawnerContainer spawnerContainer;
        public SpawnConfiguration spawnConfiguration;
        public EnemyTypesContainer enemyTypesContainer;

        void Start () {
            // void can be switched to IEnumerator for support coroutines.
            
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif
            _systems
                // register your systems here, for example:
                // .Add (new TestSystem1 ())
                // .Add (new TestSystem2 ())
                .Add(new CreatingFieldSystem())
                .Add(new CreatingSpawnersSystem())
                .Add(new InitializeSpawnTimeTrackerSystem())
                .Add(new MoveEnemySystem())
                .Add(new SpawnSystem())
                // register one-frame components (order is important), for example:
                // .OneFrame<TestComponent1> ()
                // .OneFrame<TestComponent2> ()

                // inject service instances here (order doesn't important), for example:
                // .Inject (new CameraService ())
                // .Inject (new NavMeshSupport ())
                .Inject(gameConfiguration)
                .Inject(fieldConfiguration)
                .Inject(spawnerContainer)
                .Inject(spawnConfiguration)
                .Inject(enemyTypesContainer)
                .Init ();
        }

        void Update () {
            _systems?.Run ();
        }

        void OnDestroy () {
            if (_systems != null) {
                _systems.Destroy ();
                _systems = null;
                _world.Destroy ();
                _world = null;
            }
        }   
    }
}