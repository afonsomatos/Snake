using UnityEngine;

public static class GameSettings {

    public static Difficulty difficulty = Difficulty.Medium;
    public static bool musicOn = false;
    public static bool soundOn = true;

    public static float gridUnit
    {
        get {
            return 0.3f;
        }
    }

    public static float cameraSize
    {
        get
        {
            return Camera.main.GetComponent<Camera>().orthographicSize;
        }
    }
}
