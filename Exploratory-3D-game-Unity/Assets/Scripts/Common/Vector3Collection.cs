using System;
using UnityEngine;
using zm.Util;

namespace zm.Common
{
    /// <summary>
    /// Helper class used to serialize List of Vector3 objects.
    /// </summary>
    [Serializable]
    public class Vector3Collection : GenericSerializableCollection<Vector3>
    { }
}