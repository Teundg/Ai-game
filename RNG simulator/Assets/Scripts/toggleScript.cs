using UnityEngine;

public class toggleScript : MonoBehaviour
{
    public GameObject indexPanel;
    public IndexUi indexUi;

    public void ToggleIndex()
    {
        indexPanel.SetActive(!indexPanel.activeSelf);

        if (indexPanel.activeSelf)
        {
            indexUi.Refresh();
        }
    }
}

