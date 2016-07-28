using UnityEngine;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour {

    public List<Player> players = new List<Player>();

    public bool allPlayersDead
    {
        get
        {
            return players.Count == 0;
        }
    }

    public void Kill(Player player)
    {
        players.Remove(player);
        Destroy(player.gameObject);
    }

    public IEnumerable<Transform> GetAllPlayersOccupiedBlocks()
    {
        foreach (Player player in players)
            foreach (Transform block in player.GetOccupiedBlocks())
                yield return block;
    }
}
