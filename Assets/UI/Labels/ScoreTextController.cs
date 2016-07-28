using UnityEngine;
using UnityEngine.UI;

public class ScoreTextController : MonoBehaviour {

    public Player player;

    void Update()
    {
        // TODO: Might change because of PlayerManager.players
        GetComponent<Text>().text = player.currentScore.ToString();
    }
}
