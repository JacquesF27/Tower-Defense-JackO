using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBlueprint
{
	public GameObject prefab;
	public int cost;

	public GameObject upgradedPrefab;
	public int upgradeCost;

	//public int sellValue;
	//public int upgradedSellValue;

	//to be added
	public int GetSellAmount(Node node)
	{
		if (node.isUpgraded)
		{
			return (cost + upgradeCost) / 2;
		}
		else
		{
			return cost / 2;
		}
	}
}
