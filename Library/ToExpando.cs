﻿namespace ToExpando
{
    using PropertiesHash;
    using System;
    using System.Collections.Generic;
    using System.Dynamic;

    public static class ToExpandoExtension
    {
        /// <summary>
        /// Makes a ExpandoObject out of the given object.
        /// </summary>
        /// <param name="obj">Object to become ExpandoObject</param>
        /// <returns>The ExpandoObject made</returns>
        public static ExpandoObject ToExpando(this object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            else if (obj is ExpandoObject) return (ExpandoObject)obj;
            else
            {
                var expando = new ExpandoObject();
                var dict = (IDictionary<string, object>)expando;
                foreach (var kvp in PropertiesHasher.Make(obj)) dict.Add(kvp);
                return expando;
            }
        }

        /// <summary>
        /// Removes the property of the given ExpandoObject.
        /// </summary>
        /// <param name="expando">Object to remove property from</param>
        /// <param name="propertyName">Property name to be removed</param>
        public static void RemoveProperty(this ExpandoObject expando, string propertyName)
        {
            ((IDictionary<string, object>)expando).Remove(propertyName);
        }
    }
}
