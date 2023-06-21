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
        
    }
  
    void Update()
    {
        if (isPlayerEnter == true)
        {
            _ani.SetTrigger("Open");
            SoundController.instance.SFXPlay(SoundController.sfx.StoneOpen);
            Invoke("Remove", 1f);
            makeMonster();
            isPlayerEnter = false;
        }

    }
    void Remove()
    {
        gameObject.SetActive(false);
    }

   public void makeMonster()
    {
        if (!isPlayerEnter) return;
        int ran = Random.Range(0, 10);
        Debug.Log(ran+" is ran");
        if (ran<3)
        {
            Debug.Log("Not Monster");
            
        }
        else
        {
            _moncon.SetActive(true);
            _moncon.GetComponent<MonsterController>().MakeMon();
            _hpBar.SetActive(true);
        }

    }

   
}
