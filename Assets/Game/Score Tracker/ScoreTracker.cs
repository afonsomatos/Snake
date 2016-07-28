using System;
using System.Collections.Generic;

public static class ScoreTracker {

    public static Dictionary<Difficulty, int> highscoreEntries = new Dictionary<Difficulty, int>();
    public static Dictionary<Difficulty, int> lastScore = new Dictionary<Difficulty, int>();
    public static Dictionary<Difficulty, bool> hitHighscore = new Dictionary<Difficulty, bool>();

    static ScoreTracker()
    {
        foreach (Difficulty d in Enum.GetValues(typeof(Difficulty)))
        {
            highscoreEntries.Add(d, 0);
            lastScore.Add(d, 0);
            hitHighscore.Add(d, true);
        }
    }

    public static void SaveScore(Difficulty difficulty, int score)
    {
        lastScore[difficulty] = score;

        if (score > highscoreEntries[difficulty])
        {
            highscoreEntries[difficulty] = score;
            hitHighscore[difficulty] = true;
        } else
        {
            hitHighscore[difficulty] = false;
        }
    }
}
