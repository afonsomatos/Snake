using UnityEngine;
using UnityEngine.UI;

public class ScoreTextController : MonoBehaviour {

    public Player player;

    void Update()
    {
        GetComponent<Text>().text = player.currentScore.ToString();
    }
}
