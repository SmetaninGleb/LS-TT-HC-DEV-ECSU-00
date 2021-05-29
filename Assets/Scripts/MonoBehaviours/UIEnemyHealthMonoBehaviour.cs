using UnityEngine;
using UnityEngine.UI;

namespace MonoBehaviours
{
    class UIEnemyHealthMonoBehaviour : MonoBehaviour
    {
        [SerializeField]
        private Slider HealthSlider;
        public float MaxValue;
        public float MinValue;
        public float HealthValue;
        public Camera mainCamera;
        [SerializeField]
        private Vector3 startPosition;
        [SerializeField]
        private Quaternion startRotation;


        private void Start()
        {
            startPosition = gameObject.transform.position - gameObject.transform.parent.position;
            startRotation = gameObject.transform.rotation;
        }

        private void Update()
        {
            gameObject.transform.position = gameObject.transform.parent.position + startPosition;
            gameObject.transform.rotation = startRotation;

            HealthSlider.maxValue = MaxValue;
            HealthSlider.minValue = MinValue;
            HealthSlider.value = HealthValue;
        }
    }
}
