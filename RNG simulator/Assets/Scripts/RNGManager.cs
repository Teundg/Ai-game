using System;
using UnityEngine;

public class RNGManager : MonoBehaviour
{
    public MinionDatabase database;
    public IndexUI indexUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RollMinion();
        }
    }

    void RollMinion()
    {
        Minion rolledMinion = GetRandomMinion();

        IndexManager.Instance.Discover(rolledMinion);

        PopupUI.Instance.ShowMinion(rolledMinion);

        if (indexUI != null)
        {
            indexUI.Refresh();
        }

        Debug.Log("Rolled: " + rolledMinion.minionName);
    }

    Minion GetRandomMinion()
    {
        float total = 0f;

        foreach (Minion m in database.allMinions)
        {
            total += m.dropChance;
        }

        float randomValue = UnityEngine.Random.Range(0f, total);

        foreach (Minion m in database.allMinions)
        {
            if (randomValue < m.dropChance)
            {
                return m;
            }

            randomValue -= m.dropChance;
        }

        return database.allMinions[0];
    }
}
