using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu]
    class UIConfiguration : ScriptableObject
    {
        [SerializeField]
        private GameObject _canvas;
        [SerializeField]
        private float _planeDistanceCameraCanvas;
        [SerializeField]
        private GameObject _tapToStart;
        [SerializeField]
        private GameObject _defeat;
        [SerializeField]
        private GameObject _win;
        [SerializeField]
        private GameObject _onGame;


        public GameObject Canvas => _canvas;
        public float PlaneDistanceCameraCanvas => _planeDistanceCameraCanvas;
        public GameObject TapToStart => _tapToStart;
        public GameObject Defeat => _defeat;
        public GameObject Win => _win;
        public GameObject OnGame => _onGame;
    }
}
