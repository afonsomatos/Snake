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

    void Start()
    {
        NewFruit();
    }

    Vector3 GetRandomSuitablePosition()
    {
        int maxTilesY = Mathf.FloorToInt(GameSettings.cameraSize / GameSettings.gridUnit);
        int maxTilesX = maxTilesY * Screen.width / Screen.height;

        float randomY = Random.Range(-maxTilesY, maxTilesY + 1);
        float randomX = Random.Range(-maxTilesX, maxTilesX + 1);

        return new Vector3(randomX, randomY) * GameSettings.gridUnit;
    }

    bool IsFreePosition(Vector3 pos)
    {
        bool playerFree = !playerManager.GetAllPlayersOccupiedBlocks().Select(t => t.position).Contains(pos);
        bool fruitFree = !fruitManager.GetAllFruitsOccupiedBlocks().Select(t => t.position).Contains(pos);

        return playerFree && fruitFree;
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
        Vector3 pos;

        do pos = GetRandomSuitablePosition();
        while (!IsFreePosition(pos));

        fruitManager.GenerateFruit(pos);
    }
}
