using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace zm.Questioning
{
	public static class QuestionCategoryExtensions
	{
		/// <summary>
		/// Returns text representing category.
		/// </summary>
		public static string ToText(this QuestionCategory category)
		{
			return Enum.GetName(typeof(QuestionCategory), category);
		}
	}
}

namespace zm.Util
{
	public static class TransformExtensions
	{
		/// <summary>
		/// Removes all children for passed transform.
		/// </summary>
		public static void Clear(this Transform transform)
		{
			foreach (Transform child in transform)
			{
				Object.Destroy(child.gameObject);
			}
		}
	}

	public static class ListExtensions
	{
        static System.Random random = new System.Random();

		/// <summary>
		/// Returns true if list is empty.
		/// </summary>
		public static bool IsEmpty(this IList list)
		{
			return list.Count == 0;
		}

        public static T GetRandom<T>(this List<T> list)
        {
            return list[random.Next(list.Count-1)];
        }
	}
}