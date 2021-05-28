using UnityEngine;

namespace MonoBehaviours
{
    class UIWinMonoBehaviour : MonoBehaviour
    {
        public bool IsNextGameTapped;

        private void Start()
        {
            IsNextGameTapped = false;
        }
        
        public void IsClicked()
        {
            IsNextGameTapped = true;
        }

    }
}
