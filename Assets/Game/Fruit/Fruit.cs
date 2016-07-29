using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour {

    public enum Rarity { Common, Uncommon, Rare, ExtraRare }
    public Rarity rarity;

    public int gainScore = 10;
    public AudioClip caughtSound;
}
