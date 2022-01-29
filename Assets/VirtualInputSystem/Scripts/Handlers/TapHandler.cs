using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zoca.VirtualInputSystem.Handlers
{
    /// <summary>
    /// Tap input handle.
    /// Tap normally comes across the all screen so you don't really need to have multiple
    /// action names; for this reason we always set a default tap name for this type of input.
    /// The tap action is called on pointer up toghether with the tap position.
    /// </summary>
    public class TapHandler: VirtualInputHandler
    {
        public const string DefaultName = "Tap";

        bool taping = false;
        //Vector2 position; // The position in screen coordinates

        Data.TapData data;

        public TapHandler():base(DefaultName) { }
        
        
        public void SetTap(Vector2 position)
        {
            taping = true;
            data.position = position;
            
        }

        public void ResetTap()
        {
            taping = false;
        }

        public bool GetTap(out Data.TapData data)
        {
            data = this.data;
            return taping;
        }
    }

}