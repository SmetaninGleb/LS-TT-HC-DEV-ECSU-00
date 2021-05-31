using UnityEngine;
using Leopotam.Ecs;
using Components;
using ScriptableObjects;

namespace Systems
{
    class ShootingSystem : IEcsRunSystem
    {
        private EcsFilter<RaycastHitComponent> _raycastHitFilter;
        private EcsFilter<NextProjectileComponent> _nextProjectileFilter;
        private EcsFilter<ReloadTimeTrackerComponent> _reloadTimeFilter;
        private EcsFilter<IsOnGameTrackerComponent> _isOnGameCheckingFilter;
        private ShootingConfiguration _projectilesConfiguration;
        private EcsWorld _world;

        public void Run()
        {
            if (canShot())
            {
                if (!_raycastHitFilter.IsEmpty())
                {
                    RaycastHit hit = _raycastHitFilter.Get1(0).Hit;
                    if (hit.transform != null)
                    {
                        ProjectileType projectileType = _nextProjectileFilter.Get1(0).ProjectileType;
                        _nextProjectileFilter.GetEntity(0).Destroy();
                        Vector3 projectilePosition = hit.point + Vector3.up * _projectilesConfiguration.ProjectileSpawnHeight;
                        GameObject projectileObject = GameObject.Instantiate(projectileType.ProjectileObject, projectilePosition, projectileType.ProjectileObject.transform.rotation);
                        projectileObject.GetComponent<Rigidbody>().AddForce(Vector3.down * projectileType.FlightForceMultiplier, ForceMode.Impulse);
                        EcsEntity projectileEntity = _world.NewEntity();
                        ref ProjectileComponent projectileComponent = ref projectileEntity.Get<ProjectileComponent>();
                        projectileComponent.ProjectileObject = projectileObject;
                        projectileComponent.ProjectileType = projectileType;

                        foreach (var index in _reloadTimeFilter)
                        {
                            _reloadTimeFilter.GetEntity(index).Destroy();
                        }

                        EcsEntity reloadTime = _world.NewEntity();
                        reloadTime.Get<ReloadTimeTrackerComponent>().LastShotTime = Time.timeSinceLevelLoad;
                    }
                }
            }
        }

        private bool canShot()
        {
            if (_isOnGameCheckingFilter.IsEmpty())
            {
                return false;
            }

            if (_reloadTimeFilter.IsEmpty())
            {
                return true;
            } 

            if (Time.timeSinceLevelLoad - _reloadTimeFilter.Get1(0).LastShotTime >= _projectilesConfiguration.ReloadTime)
            {
                return true;
            }

            return false;
        }
    }
}
