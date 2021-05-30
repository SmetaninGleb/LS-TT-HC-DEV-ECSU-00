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
        
        IsCollided = true;
    }
}
