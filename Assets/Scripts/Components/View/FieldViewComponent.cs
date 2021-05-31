using UnityEngine;

namespace Components
{
    struct FieldViewComponent
    {
        private GameObject fieldObject;

        public GameObject FieldObject
        {
            get { return fieldObject; }
            set { fieldObject = value; }
        }
    }
}