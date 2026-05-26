using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Minion
{
    public string minionName;
    public float dropChance;
    public Rarity rarity;

    public Sprite image;
}

public enum Rarity
{
    Common,
    Rare,
    Epic,
    Legendary,
    Mythic
}