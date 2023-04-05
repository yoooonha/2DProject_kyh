using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyMove : MonoBehaviour
{
  
    public void OnButtonGamePlay()
    {
     
        SceneManager.LoadScene("Main");
       
    }

}
