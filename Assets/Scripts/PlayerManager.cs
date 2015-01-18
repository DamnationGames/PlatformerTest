using UnityEngine;
using System.Collections;

public class PlayerData
{
	public string playerName;
	
	public PlayerData()
	{
		playerName = GameConstants.defaultPlayerName;
	}
}

public class PlayerManager : MonoBehaviour {
	public static PlayerManager Instance;
	void Awake()
	{Instance = this;}

	public PlayerData playerData;

	public void SetPlayerData(PlayerData data)
	{
		playerData = data;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
