using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StatTracking : MonoBehaviour {
	public static StatTracking Instance;
	void Awake()
	{Instance = this;}

	public List<Dictionary<string,string>> vitalLogs = new List<Dictionary<string,string>>();
	private Dictionary<string,string> errorLogs = new Dictionary<string, string>();

	public List<Dictionary<string,int>> tracking = new List<Dictionary<string,int>>();
	private Dictionary<string,int> screensVisited = new Dictionary<string, int>();

	// Use this for initialization
	void Start () {
		vitalLogs.Add(errorLogs);
		tracking.Add(screensVisited);
	}

	public void AddSessionError(string location, string error)
	{
		errorLogs.Add(error,location);
	}


//	public void AddScreenVisit(Menu screen)
//	{
//		int curVisits = 0;
//		string screenName = screen.ToString() + " Screen Visit";
//		screensVisited.TryGetValue(screenName, out curVisits);
//
//		Logging.Log (screen.ToString() + " Menu visisted " + curVisits + " times.");
//
//		curVisits += 1;
//		screensVisited.Remove(screenName);
//		screensVisited.Add(screenName,curVisits);
//	}

	public void PrintErrorLogs()
	{
		string[] keys = new string[errorLogs.Count];
		string[] values = new string[errorLogs.Count];
		errorLogs.Keys.CopyTo(keys,0);
		errorLogs.Values.CopyTo(values,0);

		for(int i=0;i<errorLogs.Count;i++)
		{
			Debug.LogError("Session error *" + values[i] + "* at " + keys[i]);
		}
	}

	public void PrintTracking()
	{
		for(int x=0; x< tracking.Count;x++) {
			string[] logKeys = new string[tracking[x].Count];
			int[] logValues = new int[tracking[x].Count];
			tracking[x].Keys.CopyTo(logKeys,0);
			tracking[x].Values.CopyTo(logValues,0);
		
			for(int i=0;i<logKeys.Length;i++)
			{
				Debug.LogError("*" + logKeys[i] + "* was triggered " + logValues[i].ToString() + " times.");
			}
		}
	}

	public void PrintTracking(int x)
	{
		string[] logKeys = new string[tracking[x].Count];
		int[] logValues = new int[tracking[x].Count];
		tracking[x].Keys.CopyTo(logKeys,0);
		tracking[x].Values.CopyTo(logValues,0);
		
		for(int i=0;i<logKeys.Length;i++)
		{
			Debug.LogError("*" + logKeys[i] + "* was triggered " + logValues[i].ToString() + " times.");
		}
	}

	void OnDestroy()
	{
		PrintErrorLogs();
	}
}
