using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zoca.VirtualInputSystem.Data
{
    public struct TapData
    {
        /// <summary>
        /// The position of your finger in screen coords.
        /// </summary>
        public Vector2 position;

        /// <summary>
        /// How long you kept your finger down.
        /// </summary>
        public float duration;
    }
}
