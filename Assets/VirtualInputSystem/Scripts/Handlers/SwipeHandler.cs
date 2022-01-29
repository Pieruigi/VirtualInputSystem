using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Zoca.VirtualInputSystem.Handlers
{
    

    public class SwipeHandler : InputHandler
    {
        public const string DefaultName = "Swipe";

        

        bool swiping = false;
        Data.SwipeData data;

        public SwipeHandler() : base(DefaultName) { }

        public void SetSwipe(Vector2 position)
        {
            if (!swiping)
            {
                swiping = true;
                data.position = position;
                data.delta = Vector2.zero;
            }
            else
            {
                data.delta = data.position - position;
                data.position = position;
            }

        }

        public void ResetSwipe()
        {
            swiping = false;
        }

        public bool GetSwipe(out Data.SwipeData info)
        {
            info = this.data;
            return swiping;
        }
    }

}
