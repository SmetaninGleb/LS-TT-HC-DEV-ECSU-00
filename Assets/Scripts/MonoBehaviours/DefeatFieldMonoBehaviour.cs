using UnityEngine;


class DefeatFieldMonoBehaviour : MonoBehaviour
{
    [SerializeField]
    private bool _isEnemyCollided;
    private bool _wasEnemyTriggerEnter;

    public bool IsEnemyCollided => _isEnemyCollided;

    private void Start()
    {
        _wasEnemyTriggerEnter = false;
    }

    private void Update()
    {
        if (!_wasEnemyTriggerEnter)
        {
            _isEnemyCollided = false;
        }
        else
        {
            _isEnemyCollided = true;
            _wasEnemyTriggerEnter = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EnemyMonoBehaviour enemyScript))
        {
            _wasEnemyTriggerEnter = true;
        }
    }
}

