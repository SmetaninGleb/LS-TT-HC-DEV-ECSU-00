using Components;
using Leopotam.Ecs;

namespace Systems
{
    class InitializeSpawnTimeTrackerSystem : IEcsInitSystem
    {
        private EcsWorld _world;
        public void Init()
        {
            EcsEntity spawnTimeTracker = _world.NewEntity();
            spawnTimeTracker.Get<SpawnTimeTrackerComponent>().LastSpawnTime = 0;
        }
    }
}
