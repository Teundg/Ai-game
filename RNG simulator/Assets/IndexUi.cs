using TMPro;
using UnityEngine;

public class IndexUi : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI indexText;
    public TextMeshProUGUI completionText;

    [Header("Data")]
    public MinionDatabase database;

    private void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        Debug.Log("INDEX REFRESHED");
        indexText.text = "";

        foreach (Minion m in database.allMinions)
        {
            if (IndexManager.Instance.IsDiscovered(m))
            {
                indexText.text += m.minionName + " (" + m.rarity + ")\n";
            }
            else
            {
                indexText.text += "???\n";
            }
        }
    }
}
