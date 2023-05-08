using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyMove : MonoBehaviour
{
    public void OnButtonGamePlay()
    {
        PlayerPrefs.SetFloat("savePlayerX", 5.97f);
        PlayerPrefs.SetFloat("savePlayerY", -1.8f);
        SceneManager.LoadScene("Main");
    }
}
