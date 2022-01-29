using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zoca.VirtualInputSystem.Handlers;

namespace Zoca.VirtualInputSystem.UI
{
    public class Taper : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        #region private fields
        [SerializeField]
        string _name;

        bool taping = false;
        TapHandler handler;
        #endregion

        #region private methods
        private void Awake()
        {
            // Create handler
            TapHandler handler = new TapHandler(_name);
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        IEnumerator Reset()
        {
            yield return new WaitForEndOfFrame();

            taping = false;
        }
        #endregion

        #region event callbacks
        public void OnDrag(PointerEventData eventData)
        {
            taping = false;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            //throw new System.NotImplementedException();
            taping = true;
            
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (taping)
            {
                // Set the handler
                handler.SetTap(true, eventData.position);

                // Reset at the end of the frame
                StartCoroutine(Reset());
            }
        }
        #endregion
    }

}
