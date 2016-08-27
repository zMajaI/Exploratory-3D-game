using System;
using System.Collections.Generic;

namespace zm.Util
{
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
}