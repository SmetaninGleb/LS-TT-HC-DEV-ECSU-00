using UnityEngine;
using UnityEngine.EventSystems;

namespace MonoBehaviours
{
    class UITapToStartMonoBehaviour : MonoBehaviour, IPointerDownHandler//, IPointerUpHandler
    {
        public bool IsTapped;

        private void Start()
        {
            IsTapped = false;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            IsTapped = true;
        }

        //public void OnPointerUp(PointerEventData eventData)
        //{
        //    IsTapped = false;
        //}
    }
}
