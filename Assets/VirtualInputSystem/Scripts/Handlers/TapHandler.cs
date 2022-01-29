using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zoca.VirtualInputSystem.Handlers
{
    public class TapHandler: VirtualInputHandler
    {
        bool taping = false;
        Vector2 position;

        public TapHandler(string name): base(name) { }

        
        public void SetTap(bool taping, Vector2 position)
        {
            this.taping = taping;
            this.position = position;
            
        }

        public bool IsTap(out Vector2 position)
        {
            position = this.position;
            return taping;
        }
    }

}
