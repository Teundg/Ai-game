using UnityEngine;

public class RNGManager : MonoBehaviour
{
    public MinionDatabase database;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RollMinion();
        }
    }

    void RollMinion()
    {
        Minion rolledMinion =
            GetRandomMinion();

        PopupUI.Instance
            .ShowMinion(rolledMinion);

        Debug.Log(
            "Rolled: " +
            rolledMinion.minionName);
    }

    Minion GetRandomMinion()
    {
        float total = 0f;

        foreach (Minion m in database.allMinions)
        {
            total += m.dropChance;
        }

        float randomValue =
            Random.Range(0, total);

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
