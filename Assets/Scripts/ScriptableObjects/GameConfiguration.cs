using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu]
    class GameConfiguration : ScriptableObject
    {
        [SerializeField]
        private Vector3 startGamePosition;

        public Vector3 StartGamePosition => startGamePosition;
    }
}
