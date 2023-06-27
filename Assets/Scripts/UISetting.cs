using UnityEngine;
using UnityEngine.UI;

public class UISetting : MonoBehaviour
{
    [SerializeField] Slider _hpBar;
    [SerializeField] GameObject _gameOver;
    [SerializeField] GameObject _attackMode;
    [SerializeField] GameObject _attackSlime;
    [SerializeField] GameObject _attackWitch;
    [SerializeField] GameObject _jail;
    
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
        if (Player._instance.BossRoom == true)
        {
            _attackMode.SetActive(true);
            _attackSlime.SetActive(false);
            _attackWitch.SetActive(true);
            _jail.SetActive(true);
        }
    }
}
