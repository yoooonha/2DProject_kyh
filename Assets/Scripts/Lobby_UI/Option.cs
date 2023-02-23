using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Option : MonoBehaviour
{
    
    private void Start()
    {
       
    }


    // Start is called before the first frame update
    public void OnButtonGameStart()
    {
     
        SceneManager.LoadScene("Main");
        Time.timeScale= 1.0f;
    }
    public void OnButtonSave()
    {

    }

    public void OnButtonGameExit()
    {
        SceneManager.LoadScene("Lobby");
    }


}
