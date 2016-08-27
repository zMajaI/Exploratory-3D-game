using System;
using System.Collections.Generic;

[Serializable]
public abstract class GenericSerializableCollection<T>
{
	#region Fields and Properties

	public List<T> Collection;

	#endregion Fields and Properties

	#region Constructor

	protected GenericSerializableCollection()
	{
		Collection = new List<T>();
	}

	#endregion Constructor
}