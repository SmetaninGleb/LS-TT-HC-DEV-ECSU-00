using UnityEngine;
using UnityEngine.UI;

namespace MonoBehaviours
{
    class UIOnGameMonoBehaviour : MonoBehaviour
    {
        public Slider TimeSlider;
        public float TimeSecondsToShow;
        public float MinValue;
        public float MaxValue;

        private void Start()
        {
            
        }

        private void Update()
        {
            TimeSlider.maxValue = MaxValue;
            TimeSlider.minValue = MinValue;
            TimeSlider.value = TimeSecondsToShow;
        }
    }
}
