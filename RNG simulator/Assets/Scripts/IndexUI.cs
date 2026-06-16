using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IndexUI: MonoBehaviour
{
    public TextMeshProUGUI indexText;
    public TextMeshProUGUI completionText;

    public MinionDatabase database;

    private void Start()
    {
        Refresh();
    }

    public void Refresh()
    {

        Debug.Log("REFRESH CALLED");

        if (IndexManager.Instance == null || database == null) return;

        indexText.text = "";

        foreach (Minion m in database.allMinions)
        {
            if (IndexManager.Instance.IsDiscovered(m))
            {
                indexText.text +=
                    $"• {m.minionName}, {m.rarity} | {m.dropChance:0.##}%\n\n";
            }
            else
            {
                indexText.text += "???\n\n\n\n\n\n\n\n";
            }
        }

        completionText.text =
            "Completion: " +
            IndexManager.Instance.GetCompletion(database.allMinions.Count) +
            "%";
    }
}
