using UnityEngine;


class ProjectileMonoBehaviour : MonoBehaviour
{
    public bool IsCollided;

    private void Start()
    {
        IsCollided = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out FieldMonoBehaviour fieldMono) 
            || collision.gameObject.TryGetComponent(out EnemyMonoBehaviour enemyMono)
            || collision.gameObject.TryGetComponent(out ObstacleMonoBehaviour obstacleMono))
        {
            IsCollided = true;
        }
    }
}
