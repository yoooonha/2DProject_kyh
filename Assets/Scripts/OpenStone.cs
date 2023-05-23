using UnityEngine;


public class OpenStone : MonoBehaviour
{
    Animator _ani;
    protected bool _isPlayerEnter;
    public bool isPlayerEnter { get { return _isPlayerEnter; } set { _isPlayerEnter = value; } }
    [SerializeField] GameObject _hpBar;
    [SerializeField] GameObject _moncon;
    void Awake()
    {
        _ani = GetComponent<Animator>();
        isPlayerEnter = false;
    }
  
    void Update()
    {
        if (isPlayerEnter == true)
        {
            _ani.SetTrigger("Open");
            makeMonster();
        }

    }

    void makeMonster()
    {
        if (!isPlayerEnter) return;
        int ran = Random.Range(0, 10);
        if (ran<3)
        {
            //Debug.Log("Not Monster");
            
        }
        else if (ran<7)
        {
          _moncon.SetActive(true);
            _hpBar.SetActive(true);
        }

    }

   
}
