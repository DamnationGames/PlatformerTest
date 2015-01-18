using UnityEngine;
using System.Collections;

public class GameSettings : MonoBehaviour {
	public static GameSettings Instance;
	void Awake()
	{Instance = this;}

	public bool VERBOSE = false;
}
