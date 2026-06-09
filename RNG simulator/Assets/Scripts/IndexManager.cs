using System.Collections.Generic;
using UnityEngine;

public class IndexManager : MonoBehaviour
{
    public static IndexManager Instance;

    public HashSet<string> discovered = new HashSet<string>();

    private void Awake()
    {
        Debug.Log("INDEX MANAGER AWAKE");
        Instance = this;
    }

    public void Discover(Minion minion)
    {
        if (!discovered.Contains(minion.id))
        {
            discovered.Add(minion.id);
        }
    }

    public bool IsDiscovered(Minion minion)
    {
        return discovered.Contains(minion.id);
    }

    public int GetCompletion(int total)
    {
        return (int)((discovered.Count / (float)total) * 100f);
    }
}
