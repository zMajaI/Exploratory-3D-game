using UnityEngine;
using System.Collections;
using zm.Questioning;

namespace zm.Levels
{
    public class QuestionableObjectView : MonoBehaviour
    {
        #region Fields and Properties
        [SerializeField]
        private bool rotate;

        [SerializeField]
        private float rotateSpeed = 50f;

        [SerializeField]
        private GameObject cube;

        #endregion Fields and Properties

        #region MonoBehaviour Methods

        // Update is called once per frame
        void Update()
        {
            if (rotate)
            {
                cube.transform.Rotate(new Vector3(0f, Time.deltaTime * rotateSpeed, 0f));
            }
            else
            {
                cube.transform.rotation = Quaternion.Euler(Vector3.zero);
            }
        }

        public void OnTriggerEnter(Collider other)
        {
            rotate = true;
            Debug.Log("<color=magenta> T Enter <color>");
        }

        public void OnTriggerExit(Collider other)
        {
            rotate = false;
            Debug.Log("<color=magenta> T Exit <color>");
        }

        #endregion MonoBehaviour Methods

        public void OnCollisionExit(Collision collision)
        {
            Debug.Log("<color=magenta>  Enter <color>");
        }

        public void OnCollisionEnter(Collision collision)
        {
            Debug.Log("<color=magenta> Enter <color>");
        }

        #region Public Methods

        public void Initialize(Question question)
        {

        }

        #endregion Public Methods
    }
}