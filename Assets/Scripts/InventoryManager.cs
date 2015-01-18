using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryCategory
{
	public string name;
	public CollectableType type;
	public Region region;
	public int count;
	public int max;
	
	public InventoryCategory(CollectableType itemType, Region itemRegion, int itemCount, int itemMax)
	{
		name = itemType.ToString();
		type = itemType;
		region = itemRegion;
		count = itemCount;
		max = itemMax;
	}

	public InventoryCategory(string itemName, CollectableType itemType, Region itemRegion, int itemCount, int itemMax)
	{
		name = itemName;
		type = itemType;
		region = itemRegion;
		count = itemCount;
		max = itemMax;
	}

	public void Increment(bool isAdding)
	{
		if(isAdding)
			++count;
		else
			--count;

		if(count < 0)
			count = 0;
		else if(count > max)
			count = max;
	}
}

public class InventoryManager : MonoBehaviour {
	public static InventoryManager Instance;
	void Awake()
	{Instance = this;}

	public List<InventoryCategory> inventory = new List<InventoryCategory>();

	void Start()
	{

	}

	public void SetInventory(List<InventoryCategory> inv)
	{
		inventory = inv;
	}

	public List<InventoryCategory> NewInventory()
	{
		List<InventoryCategory> newInventory = new List<InventoryCategory>();

		newInventory.Add(new InventoryCategory(CollectableType.Powerup,(Region)0,0,1));
		newInventory.Add(new InventoryCategory("Health Upgrades",CollectableType.Upgrade,(Region)0,0,3));
		newInventory.Add(new InventoryCategory("Extra Moves", CollectableType.Upgrade,(Region)0,0,25));
		newInventory.Add(new InventoryCategory(CollectableType.Quest,(Region)0,0,10));
		
		newInventory.Add(new InventoryCategory(CollectableType.Quest,(Region)1,0,5));
		newInventory.Add(new InventoryCategory(CollectableType.Upgrade,(Region)1,0,5));
		
		newInventory.Add(new InventoryCategory(CollectableType.Star,(Region)2,0,10));
		newInventory.Add(new InventoryCategory(CollectableType.Quest,(Region)2,0,10));
		
		newInventory.Add(new InventoryCategory(CollectableType.Coin,(Region)3,0,99));
		newInventory.Add(new InventoryCategory(CollectableType.Star,(Region)3,0,10));
		newInventory.Add(new InventoryCategory(CollectableType.Quest,(Region)3,0,5));
		newInventory.Add(new InventoryCategory(CollectableType.Upgrade,(Region)3,0,3));
		
		newInventory.Add(new InventoryCategory(CollectableType.Coin,(Region)4,0,99));
		newInventory.Add(new InventoryCategory(CollectableType.Star,(Region)4,0,10));
		newInventory.Add(new InventoryCategory(CollectableType.Quest,(Region)4,0,5));
		newInventory.Add(new InventoryCategory(CollectableType.Upgrade,(Region)4,0,3));

		return newInventory;
	}

	public void AddToInventory(CollectableType itemType, Region itemRegion, bool isAdding = true)
	{
		foreach(InventoryCategory category in inventory)
		{
			if(category.type == itemType && category.region == itemRegion)
			{
				category.Increment(isAdding);
			}
		}
	}

	public string GetInventoryDisplay()
	{
		string display = "***\n";

		for(int i=0; i<(int)Region.NumberOfRegions;i++)
		{
			display += ((Region)i).ToString() + ":\n\n";

			foreach(InventoryCategory category in inventory)
			{
				if((int)category.region == i)
				{
					display += category.name + ": " + category.count.ToString() + "/" + category.max.ToString() + "   ";
				}
			}

			display += "\n***\n";
		}

		return display;
	}
}
