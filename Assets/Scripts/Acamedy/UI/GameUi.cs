using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUi : MonoBehaviour
{
    [SerializeField] Image _expGauge;
    private void Update()
    {
        _expGauge.transform.localScale += new Vector3(Time.deltaTime,0,0);
        if (_expGauge.transform.localScale.x >= 1) _expGauge.transform.localScale = new Vector3(0, 1, 1);
    }
    // Start is called before the first frame update
  public void OnButtonToLobby()
    {
        SceneManager.LoadScene("Lobby");
    }
    public void OnButtonReGame()
    {
        SceneManager.LoadScene("Main");
    }
}
