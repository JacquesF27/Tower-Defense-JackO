using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    private Node target;

	public GameObject ui;

	public Text upgradeCost;
	public Button upgradeButton;

	public Text sellValueText;
	public Button sellButton;

    public void SetTarget(Node _target)
	{
		target = _target;

		transform.position = target.GetBuildPosition();

		

		if (!target.isUpgraded)
		{
			upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
			upgradeButton.interactable = true;
		}
		else
		{
			upgradeCost.text = "MAX";
			upgradeButton.interactable = false;
		}

		sellValueText.text = "$" + target.turretBlueprint.GetSellAmount(target);

		ui.SetActive(true);
	}

	public void Hide()
	{
		ui.SetActive(false);
	}

	public void Upgrade()
	{
		target.UpgradeTurret();
		BuildManager.instance.DeselectNode();
	}

	public void Sell()
	{

		Debug.Log("Turret sold for: " + sellValueText);
		target.SellTurret();
		BuildManager.instance.DeselectNode();
	}
}
