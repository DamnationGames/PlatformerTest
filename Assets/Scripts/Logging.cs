using UnityEngine;
using System.Collections;

public static class Logging{
	public static void Log(string message, bool isError = false)
	{
		if(GameSettings.Instance.VERBOSE){
			if(isError)
				Debug.LogError(message);
			else
				Debug.Log(message);
		}
	}

	public static void VitalLog(string message, string location)
	{
		Debug.LogError("VITAL MESSAGE:" + message);

		StatTracking.Instance.AddSessionError(location,message);
	}
}
