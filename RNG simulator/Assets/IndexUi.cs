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
        if (indexText == null || completionText == null || database == null)
        {
            Debug.LogError("IndexUi: Missing references!");
            return;
        }

        if (IndexManager.Instance == null)
        {
            Debug.LogError("IndexUi: IndexManager instance not found!");
            return;
        }

        indexText.text = "";

        foreach (Minion m in database.allMinions)
        {
            indexText.text += "TEST ???\n";
        }

        completionText.text =
            $"Completion: {IndexManager.Instance.discovered.Count}/{database.allMinions.Count}";
    }
}
