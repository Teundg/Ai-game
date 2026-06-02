using TMPro;
using UnityEngine;

public class IndexUI : MonoBehaviour
{
    public TextMeshProUGUI indexText;
    public TextMeshProUGUI completionText;

    public MinionDatabase database;

    public void Refresh()
    {
        indexText.text = "";

        foreach (Minion m in database.allMinions)
        {
            if (IndexManager.Instance.IsDiscovered(m))
            {
                indexText.text +=
                    m.minionName + " | " +
                    m.rarity + "\n";
            }
            else
            {
                indexText.text += "???\n";
            }
        }

        completionText.text =
            "Completion: " +
            IndexManager.Instance.GetCompletion(database.allMinions.Count) +
            "%";
    }
}
