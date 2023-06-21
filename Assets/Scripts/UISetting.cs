using UnityEngine;
using UnityEngine.UI;

public class UISetting : MonoBehaviour
{
    [SerializeField] Slider _hpBar;
    [SerializeField] GameObject _gameOver;
    void Start()
    {
        _hpBar = Player._instance._Hpbar;
       
    }

    void Update()
    {
        if (Player._instance.IsGameOver == true)
        {
            _gameOver.SetActive(true);
        }
    }
}
