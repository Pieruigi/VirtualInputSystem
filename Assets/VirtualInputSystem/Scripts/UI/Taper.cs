using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zoca.VirtualInputSystem.Handlers;

namespace Zoca.VirtualInputSystem.UI
{
    public class Taper : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        #region private fields
        [SerializeField]
        [Tooltip("How much time you can keep your finger down before the tap action fail. " +
            "Set zero if you want to keep your finger down forever. Default: 0.5 sec.")]
        float tapTime = 0.5f;

        bool taping = false;
        TapHandler handler;
        float elapsed = 0;
        #endregion

        #region private methods
        private void Awake()
        {
            // Create handler
            handler = new TapHandler();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (taping)
            {
                if(elapsed > 0)
                {
                    elapsed -= Time.deltaTime;

                    if (elapsed <= 0)
                        taping = false;
                }
                
            }
        }

        IEnumerator Reset()
        {
            yield return new WaitForEndOfFrame();

            taping = false;
            handler.ResetTap();
        }
        #endregion

        #region event callbacks
        /// <summary>
        /// You have to tap, not to drag.
        /// </summary>
        /// <param name="eventData"></param>
        public void OnDrag(PointerEventData eventData)
        {
            taping = false;
            elapsed = 0;
            handler.ResetTap();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            //throw new System.NotImplementedException();
            taping = true;
            elapsed = tapTime;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (taping)
            {
                elapsed = 0;

                // Set the handler
                handler.SetTap(eventData.position);

                // Reset at the end of the frame
                StartCoroutine(Reset());
            }
        }
        #endregion
    }

}
