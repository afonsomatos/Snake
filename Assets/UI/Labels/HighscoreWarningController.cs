using UnityEngine;

public class HighscoreWarningController : MonoBehaviour {

    void Start()
    {
        if (ScoreTracker.hitHighscore[GameSettings.difficulty] == false) {
            Destroy(gameObject);
        }
    }
}
