using UnityEngine;
using System.Collections.Generic;
using System;

[Serializable]
public abstract class GenericSerializableCollection<T>
{

    #region Fields and Properties

    public List<T> Collection;

    #endregion Fields and Properties

    #region Constructor

    public GenericSerializableCollection()
    {
        Collection = new List<T>();
    }

    #endregion Constructor
}
