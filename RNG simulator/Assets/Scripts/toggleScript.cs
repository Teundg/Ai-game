using UnityEngine;

public class toggleScript : MonoBehaviour
{
    public GameObject indexPanel;

    public void ToggleIndex()
    {
        indexPanel.SetActive(!indexPanel.activeSelf);
    }
}
