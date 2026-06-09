using System;
using UnityEngine;

public class RNGManager : MonoBehaviour
{
    public MinionDatabase database;

    void Start()
    {
        Debug.Log("IndexManager Instance at start: " + IndexManager.Instance);
    }
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

        Debug.Log("Got minion");

        Debug.Log(IndexManager.Instance);

        Debug.Log(PopupUI.Instance);

        IndexManager.Instance.Discover(rolledMinion);

        PopupUI.Instance.ShowMinion(rolledMinion);

        Debug.Log("Rolled: " + rolledMinion.minionName);
    }

    Minion GetRandomMinion()
    {
        float total = 0f;

        foreach (Minion m in database.allMinions)
        {
            total += m.dropChance;
        }

        // FIXED: UnityEngine.Random (no ambiguity)
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
