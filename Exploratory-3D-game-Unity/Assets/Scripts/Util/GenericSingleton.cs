namespace zm.Util
{
	public abstract class GenericSingleton<T> where T : class, new()
	{

		#region Fields and Properties

		private static T instance;

		public static T Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new T();
				}
				return instance;
			}
		}

		#endregion Fields and Properties
	}
}