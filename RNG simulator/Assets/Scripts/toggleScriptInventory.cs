using UnityEngine;

public class toggleScriptInventory : MonoBehaviour
{
    public GameObject inventoryPanel;

    public void ToggleIndex()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
    }
}
