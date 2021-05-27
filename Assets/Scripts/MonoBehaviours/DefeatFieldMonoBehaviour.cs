using UnityEngine;


class DefeatFieldMonoBehaviour : MonoBehaviour
{
    private bool _isEnemyCollided;

    public bool IsEnemyCollided => _isEnemyCollided;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EnemyMonoBehaviour enemyScript))
        {
            _isEnemyCollided = true;
        } else
        {
            _isEnemyCollided = false;
        }
    }
}

