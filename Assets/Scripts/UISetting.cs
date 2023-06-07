using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

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
