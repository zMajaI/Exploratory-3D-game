using System.Collections.Generic;
using UnityEngine;
using zm.Questioning;
using zm.Util;

public class QuestionPrefabsProvider : GenericSingleton<QuestionPrefabsProvider>
{
	#region Constants

	/// <summary>
	/// Path in resources folder on which these prefabs can be found.
	/// </summary>
	private const string PrefabPath = "Prefabs/Levels/QuestionableObjects/obj_";

	#endregion Constants

	#region Public Methods

	public GameObject GetPrefab(QuestionCategory category)
	{
		currentIndexByCategory[category]++;
		currentIndexByCategory[category] %= maxIndexByCategory[category];

		return Resources.Load<GameObject>(PrefabPath + category + "_" + currentIndexByCategory[category]);
	}

	#endregion Public Methods

	#region Fields and Properties

	/// <summary>
	/// Defines max number of elements by category.
	/// </summary>
	private readonly Dictionary<QuestionCategory, int> maxIndexByCategory = new Dictionary<QuestionCategory, int>
	{
		{QuestionCategory.Hogwarts, 1},
		{QuestionCategory.Potions, 1},
		{QuestionCategory.Spells, 1}
	};

	/// <summary>
	/// Dictionary holding current index for category. Used to return different game object each time.
	/// </summary>
	private readonly Dictionary<QuestionCategory, int> currentIndexByCategory = new Dictionary<QuestionCategory, int>
	{
		{QuestionCategory.Hogwarts, -1},
		{QuestionCategory.Potions, -1},
		{QuestionCategory.Spells, -1}
	};

	#endregion Fields and Properties
}