using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GameController : MonoBehaviour {

    public AudioClip deathSound;
    public LevelManager levelManager;
    public PlayerManager playerManager;
    public SoundManager soundManager;
    public FruitManager fruitManager;

    private int maxTilesY
    {
        get { return Mathf.FloorToInt(GameSettings.cameraSize / GameSettings.gridUnit); }
    }

    private int maxTilesX
    {
        get { return maxTilesY * Screen.width / Screen.height; }
    }

    private bool noFreePositions
    {
        get { return playerManager.GetAllPlayersOccupiedBlocks().Count() >= (maxTilesX * 2 + maxTilesY + 2); }
    }

    void Start()
    {
        NewFruit();
    }

    bool IsFreePosition(Vector3 pos)
    {
        bool playerFree = !playerManager.GetAllPlayersOccupiedBlocks().Select(t => t.position).Contains(pos);
        bool fruitFree = !fruitManager.GetAllFruitsOccupiedBlocks().Select(t => t.position).Contains(pos);

        return playerFree && fruitFree;
    }

    Vector3 GetFreePosition()
    {
        List<Vector3> positions = new List<Vector3>();

        IEnumerable<int> rangeY = Enumerable.Range(-maxTilesY, maxTilesY + 1);
        IEnumerable<int> rangeX = Enumerable.Range(-maxTilesX, maxTilesX + 1);

        foreach (int x in rangeX)
        {
            foreach (int y in rangeY)
            {
                Vector3 pos = new Vector3(x, y) * GameSettings.gridUnit;
                if (IsFreePosition(pos))
                {
                    positions.Add(pos);
                }
            }
        }

        return positions.ElementAt(Random.Range(0, positions.Count));
    }

    public void PlayerDead(Player player, Player.Death typeOfDeath)
    {
        playerManager.Kill(player);
        ScoreTracker.SaveScore(GameSettings.difficulty, player.currentScore);
        soundManager.PlaySound(deathSound);
        if (playerManager.allPlayersDead)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        levelManager.LoadNextLevel();
    }

    public void FruitCaught(Fruit fruit)
    {
        fruitManager.RemoveFruit(fruit);
        soundManager.PlaySound(fruit.caughtSound);
        NewFruit();
    }

    public void NewFruit()
    {
        // Fixes #3
        if (noFreePositions)
        {
            EndGame();
        }

        fruitManager.GenerateFruit(GetFreePosition());
    }
}
