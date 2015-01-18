using UnityEngine;
using System.Collections;

public class RegionManager : MonoBehaviour {
	public static RegionManager Instance;
	void Awake()
	{Instance = this;}
	
	public Region region;
	public string regionName;

	private Region targetRegion;

	public Region GetCurrentRegion()
	{
		return region;
	}

	public string GetCurrentRegionName()
	{
		return regionName;
	}

	public void SetRegionData()
	{
		GameController.Instance.SetCurrentRegion(region);
	}

	public void SetTargetRegion(Region tarRegion)
	{
		targetRegion = tarRegion;
	}

	public Region GetTargetRegion()
	{
		return targetRegion;
	}

	public void TransitionRegions()
	{

	}
}
