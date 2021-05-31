using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    class EnemyDeathSystem : IEcsRunSystem
    {
        private EcsFilter<EnemyComponent> _enemyFilter;

        public void Run()
        {
            foreach (var index in _enemyFilter)
            {
                EcsEntity enemyEntity = _enemyFilter.GetEntity(index);
                GameObject enemyobject = _enemyFilter.Get1(index).EnemyObject;
                int health = enemyobject.GetComponent<EnemyMonoBehaviour>().Health;
                if (health <= 0)
                {
                    GameObject.Destroy(enemyobject);
                    enemyEntity.Destroy();
                }
            }
        }
    }
}
