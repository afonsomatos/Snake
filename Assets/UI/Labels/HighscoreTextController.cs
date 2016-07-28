using UnityEngine;
using UnityEngine.UI;

[RequireComponent( typeof(Text) )]
public class HighscoreTextController : MonoBehaviour {

    void Update()
    {
        GetComponent<Text>().text = ScoreTracker.highscoreEntries[GameSettings.difficulty].ToString();
    }
}
