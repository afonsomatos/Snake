using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

public class FruitManager : MonoBehaviour {

    public Fruit fruit;
    private List<Fruit> allFruits = new List<Fruit>();

    public void GenerateFruit(Vector3 pos)
    {
        Fruit newFruit = Instantiate(fruit, pos, Quaternion.identity) as Fruit;
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
