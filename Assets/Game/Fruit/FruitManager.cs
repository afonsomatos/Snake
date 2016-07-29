using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System;

using Random = UnityEngine.Random;

public class FruitManager : MonoBehaviour {

    [Serializable]
    public struct RarityProb
    {
        public Fruit.Rarity rarity;
        public float relativeProb;
    }

    public Fruit[] fruits;
    public RarityProb[] rarityProbs;

    private List<Fruit> allFruits = new List<Fruit>();

    Fruit GetRandomFruitType()
    {
        float rand = Random.Range(0, rarityProbs.Sum(f => f.relativeProb));
        Fruit.Rarity rarity = Fruit.Rarity.Common;

        float i = 0;
        foreach (RarityProb rp in rarityProbs)
        {
            i += rp.relativeProb;
            if (i >= rand)
            {
                rarity = rp.rarity;
                break;
            }
        }

        Fruit[] possible = fruits.Where(f => f.rarity == rarity).ToArray();

        return possible[Random.Range(0, possible.Length)];
    }

    public void GenerateFruit(Vector3 pos)
    {
        Fruit randFruit = GetRandomFruitType();
        Fruit newFruit = Instantiate(randFruit, pos, Quaternion.identity) as Fruit;
        allFruits.Add(newFruit);
    }

    public Fruit CheckCaughtFruit(Vector3 pos)
    {
        Fruit caughtFruit = allFruits.FirstOrDefault(f => f.transform.position == pos);
        return caughtFruit;
    }

    public void RemoveFruit(Fruit fruit)
    {
        Destroy(fruit.gameObject);
        allFruits.Remove(fruit);
    }

    public IEnumerable<Transform> GetAllFruitsOccupiedBlocks()
    {
        foreach (Fruit fruit in allFruits)
            yield return fruit.transform;
    }
}
