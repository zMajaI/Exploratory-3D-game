using System;
using zm.Util;

namespace zm.Levels
{
    /// <summary>
    /// Class that holds collection of levels, it's used to enable serialization of List<Level>
    /// </summary>
    [Serializable]
    public class LevelsCollection : GenericSerializableCollection<Level>
    { }
}