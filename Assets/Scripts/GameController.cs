using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameData
{
	public PlayerData playerData;
	public List<InventoryCategory> inventory = new List<InventoryCategory>();
	public Region region;
	
	public GameData()
	{
		playerData = new PlayerData();
		inventory = new List<InventoryCategory>();
		region = Region.Prologue;
	}
	
	public GameData(PlayerData curPlayerData, List<InventoryCategory> curInventory, Region curRegion)
	{
		playerData = curPlayerData;
		inventory = curInventory;
		region = curRegion;
	}
}

public class GameController : MonoBehaviour {
	public static GameController Instance;
	void Awake()
	{Instance = this;}

	private GameData gameData;

	void Start()
	{
		if(gameData == null)
		{
			Logging.Log ("Game Data is null, initializing...");
			if(PlayerPrefs.HasKey(DataKeys.GAME_DATA_EXISTS))
				LoadGameData();
			else
				CreateGameData();
		}
	}

	private void SaveGameData()
	{
		// TODO Need to figure these out
	}

	private void LoadGameData()
	{
		// TODO Need to figure these out
	}

	private void CreateGameData()
	{
		SetCurrentGameData(new PlayerData(),InventoryManager.Instance.NewInventory(),Region.Prologue);
		UpdateGameData();
	}

	private void UpdateGameData()
	{
		PlayerManager.Instance.SetPlayerData(gameData.playerData);
		InventoryManager.Instance.SetInventory(gameData.inventory);
		RegionManager.Instance.SetTargetRegion(gameData.region);
	}

	public void SetCurrentGameData(PlayerData curPlayerData, List<InventoryCategory> curInventory, Region curRegion) 
	{
		gameData = new GameData(curPlayerData,curInventory,curRegion);
		UpdateGameData();
	}

	public void SetCurrentGameData(GameData curGameData) 
	{
		gameData = curGameData;
		UpdateGameData();
	}

	public void SetCurrentPlayerData(PlayerData curPlayerData)
	{
		gameData.playerData = curPlayerData;
		UpdateGameData();
	}

	public void SetCurrentInventory(List<InventoryCategory> curInventory)
	{
		gameData.inventory = curInventory;
		UpdateGameData();
	}

	public void SetCurrentRegion(Region curRegion)
	{
		gameData.region = curRegion;
		UpdateGameData();
	}

	public GameData GetCurrentGameData()
	{
		return gameData;
	}
}
