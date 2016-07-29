using UnityEngine;

public class StandaloneOnly : MonoBehaviour {

    void Start()
    {
        // #1
        #if (!UNITY_STANDALONE)
            Destroy(gameObject);
        #endif
    }
}
