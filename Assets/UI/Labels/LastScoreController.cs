using UnityEngine;
using UnityEngine.UI;

public class LastScoreController : MonoBehaviour {

    void Start()
    {
        GetComponent<Text>().text = ScoreTracker.lastScore[GameSettings.difficulty].ToString();
    }
}
