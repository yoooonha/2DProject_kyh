using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyMove : MonoBehaviour
{
    private void Start()
    {
        //PlayerPrefs.DeleteAll();
    }
    public void OnButtonGamePlay()
    {
        SoundController.instance.SFXPlay(SoundController.sfx.Click);
        PlayerPrefs.SetFloat("savePlayerX", 5.97f);
        PlayerPrefs.SetFloat("savePlayerY", -1.8f);
        SceneManager.LoadScene("Main");
    }
}
