using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour{

    public static Singleton<T> instance { get; private set; }
    
    protected virtual void Start()
    {
        if (instance)
        {
            Destroy(gameObject);
        } else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
