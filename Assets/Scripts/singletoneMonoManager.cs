using UnityEngine;

public class singletoneMonoManager : MonoBehaviour
{
    public static singletoneMonoManager _instance;
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
