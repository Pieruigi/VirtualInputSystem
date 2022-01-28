using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zoca.VirtualInputSystem.Handlers;

namespace Zoca.VirtualInputSystem
{
    /// <summary>
    /// An hub containing all the virtual input handles.
    /// You can register a new handle or unregister an existing one or get existing axis to
    /// check input value.
    /// </summary>
    public class VirtualInput
    {
        static List<VirtualInputHandler> handlers = new List<VirtualInputHandler>();

        static VirtualAxisHandler FindAxis(string name)
        {
            return (VirtualAxisHandler)handlers.Find(h => h.GetType() == typeof(VirtualAxisHandler) && h.Name.Equals(name));
        }

        static VirtualButtonHandler FindButton(string name)
        {
            return (VirtualButtonHandler)handlers.Find(h => h.GetType() == typeof(VirtualButtonHandler) && h.Name.Equals(name));
        }

        /// <summary>
        /// Register a new virtual input handle
        /// </summary>
        /// <param name="handler"></param>
        public static void RegisterHandler(VirtualInputHandler handler)
        {
            if(handlers.Exists(h=>h.Name.Equals(handler.Name)))
                throw new System.Exception("Virtual input " + handler.Name + " already exists.");

            handlers.Add(handler);
        }

        /// <summary>
        /// Unregister an existing virtual input handle
        /// </summary>
        /// <param name="handler"></param>
        public static void UnregisterHandler(VirtualInputHandler handler)
        {
            handlers.Remove(handler);
        }

        /// <summary>
        /// Returns the virtual axis value if exists, otherwise an exception is thrown.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static float GetAxis(string name)
        {
            return  FindAxis(name).Value;
            
        }

        /// <summary>
        /// Returns the virtual axis raw value if exists, otherwise an exception is thrown.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static float GetAxisRaw(string name)
        {
            return FindAxis(name).ValueRaw;

        }

        public static bool GetButtonDown(string name)
        {
            return FindButton(name).State == (int)ButtonState.Down;
        }

        public static bool GetButton(string name)
        {
            return FindButton(name).State == (int)ButtonState.KeepDown;
        }

        public static bool GetButtonUp(string name)
        {
            return FindButton(name).State == (int)ButtonState.Up;
        }
    }

}
