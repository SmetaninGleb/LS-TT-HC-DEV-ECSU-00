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
        public DefeatFieldConfiguration defeatFieldConfiguration;
        public ShootingConfiguration shootingConfiguration;
        public ProjectileTypeContainer projectileTypeContainer;
        public ObstacleTypesContainer obstacleTypeContainer;
        public ObstacleSpawnConfiguration obstacleSpawnConfiguration;
        public UIConfiguration uiConfiguration;
        public NavMeshConfiguration navMeshConfiguration;

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
                .Add(new InitializeGameSystem())
                .Add(new StartGameTrackerSystem())
                .Add(new CreatingDefeatFieldSystem())
                .Add(new CreatingFieldSystem())
                .Add(new UIInitializeSystem())
                .Add(new CreatingSpawnersSystem())
                .Add(new InitializeNavMeshSystem())
                .Add(new InitObstacleSpawnSystem())
                .Add(new InitializeSpawnTimeTrackerSystem())
                .Add(new UITapToStartGameSystem())
                .Add(new DefeatCheckingSystem())
                .Add(new SpawnSystem())
                .Add(new UIHealthEnemySystem())
                .Add(new MoveEnemySystem())
                .Add(new TouchHandlerSystem())
                .Add(new RayFromTouchSystem())
                .Add(new RaycastHandlerSystem())
                .Add(new ProjectileTypeOrderSystem())
                .Add(new UINextProjectileSystem())
                .Add(new ShootingSystem())
                .Add(new ExplosionHandlerSystem())
                .Add(new MakeExplosionSystem())
                .Add(new MakeExplosionParticlesSystem())
                .Add(new ApplyingDamageSystem())
                .Add(new ApplyingObstacleForceSystem())
                .Add(new EnemyDeathSystem())
                .Add(new DeleteExplosionParticlesSystem())
                .Add(new ExplosionSystem())
                .Add(new WinCheckingSystem())
                .Add(new UIOnGameSystem())
                .Add(new EndTimeTrackerSystem())
                .Add(new UIWinSystem())
                .Add(new UIDefeatSystem())
                .Add(new EnemyOnWinSystem())
                .Add(new EnemyOnDefeatSystem())
                .Add(new EnemyOnFinishGameSystem())
                .Add(new ObstacleOnFinishSystem())
                .Add(new FinishGameTrackerSystem())
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
                .Inject(defeatFieldConfiguration)
                .Inject(shootingConfiguration)
                .Inject(projectileTypeContainer)
                .Inject(uiConfiguration)
                .Inject(navMeshConfiguration)
                .Inject(obstacleTypeContainer)
                .Inject(obstacleSpawnConfiguration)
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