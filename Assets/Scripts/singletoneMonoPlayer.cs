using UnityEngine;

public class singletoneMonoPlayer : MonoBehaviour
{
    public static singletoneMonoPlayer _instance;
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(_instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
