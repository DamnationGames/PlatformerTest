using UnityEngine;
using System.Collections;

public enum CollectableType
{
	Coin,
	Star,
	Powerup,
	Quest,
	Upgrade,
	Skill,
	NumberOfCollectableTypes
}

public enum Region
{
	Meta,
	Prologue,
	OverWorld,
	World_01,
	World_02,
	Test,
	NumberOfRegions
}

public class Collectable : MonoBehaviour {
	public string name;
	public CollectableType type;
	public Region region;
	public bool lockState;

	public GameObject itemObject;
	public Collider pickupCollider;

	public void Collect()
	{
		if(lockState)
		{
			Debug.LogError("Cannot collect. Item is locked");
			return;
		}

		InventoryManager.Instance.AddToInventory(type,region);
		Collect (type,region);

		itemObject.SetActive(false);
	}

	private void Collect(CollectableType itemType,Region itemRegion)
	{
		switch(itemType)
		{
		case CollectableType.Coin:
			CollectCoin();
			break;
		case CollectableType.Star:
			CollectStar(itemRegion);
			break;
		case CollectableType.Powerup:
			CollectPowerup();
			break;
		case CollectableType.Quest:
			CollectQuestItem(itemRegion);
			break;
		case CollectableType.Upgrade:
			CollectUpgrade();
			break;
		case CollectableType.Skill:
			CollectSkill();
			break;
		}
	}

	public void CollectCoin()
	{

	}

	public void CollectStar(Region itemRegion)
	{
		
	}

	public void CollectPowerup()
	{
		
	}

	public void CollectQuestItem(Region itemRegion)
	{
		
	}

	public void CollectUpgrade()
	{
		
	}

	public void CollectSkill()
	{
		
	}


	public void Lock(bool locked = true)
	{
		lockState = locked;
	}
}
