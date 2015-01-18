using UnityEngine;
using System.Collections;

public class InventoryDisplay : MonoBehaviour {
	public static InventoryDisplay Instance;
	void Awake()
	{Instance = this;}

	public UILabel inventoryLabel;
	public GameObject inventoryDisplayObject;

	public void DisplayInventory()
	{

	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.I))
		{
			inventoryLabel.text = InventoryManager.Instance.GetInventoryDisplay();
			inventoryDisplayObject.SetActive(true);
		} else {
			inventoryDisplayObject.SetActive(false);
		}
	}
}
