using UnityEngine;

//Superclass

[System.Serializable] //Nilagay to sa taas para serializable buong script

public class DropSystem
{
    public string ItemName;
    public GameObject ItemPrefab;
    [Range(0,100)] //for Drop Chance
    public float DropChance;
    public int min, max;
    public float duration;
}
