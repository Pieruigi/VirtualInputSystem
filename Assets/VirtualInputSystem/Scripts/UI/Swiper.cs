using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zoca.VirtualInputSystem.Handlers;

namespace Zoca.VirtualInputSystem.UI
{
    public class Swiper : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {

        //bool swiping = false;
        SwipeHandler handler;

        private void Awake()
        {
            handler = new SwipeHandler();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnDrag(PointerEventData eventData)
        {
            //swiping = true;
            handler.SetSwipe(eventData.position);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            //swiping = false;
            handler.ResetSwipe();
        }
    }

}
