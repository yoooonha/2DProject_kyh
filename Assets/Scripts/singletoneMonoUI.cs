using UnityEngine;

public class singletoneMonoUI : MonoBehaviour
{
    public static singletoneMonoUI _instance;
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
