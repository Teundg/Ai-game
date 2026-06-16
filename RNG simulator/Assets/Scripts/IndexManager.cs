using System.Collections.Generic;
using UnityEngine;

public class IndexManager : MonoBehaviour
{
    public static IndexManager Instance;

    public HashSet<string> discovered = new HashSet<string>();

    private void Awake()
    {
        Instance = this;
    }

    // STEP 1: Call this when player gets a minion
    public void Discover(Minion m)
    {
        if (m == null) return;

        discovered.Add(m.minionName);
    }

    // Used by UI to check if minion is unlocked
    public bool IsDiscovered(Minion m)
    {
        if (m == null) return false;

        return discovered.Contains(m.minionName);
    }

    // STEP 1 (your missing function) — completion %
    public float GetCompletion(int totalMinions)
    {
        if (totalMinions == 0) return 0f;

        return (float)discovered.Count / totalMinions * 100f;
    }
}
