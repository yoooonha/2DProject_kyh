using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundController : MonoBehaviour
{
    public static SoundController instance;

    [SerializeField] AudioSource _bgmPlayer;
    [SerializeField]AudioClip[] _bgms;
    [SerializeField] AudioSource[] _sfxPlayer;
    [SerializeField]AudioClip[] _sfxs;

    public enum sfx {
        Click,
        StoneOpen,
        Attack,
        SlimeAttack,
        SlimeDeath,
        GetItem,
        GameOver

    };
    int sfxIndex;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
            SceneManager.sceneLoaded += OnsceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void OnsceneLoaded(Scene _scene,LoadSceneMode _scene1)
    {
        
        for(int i=0;i< _bgms.Length;i++)
        {
            // Scene in Build
            //0 Lobby
            //1 Main
            //2 Dunjeon
            //3 House1
            if (_scene.buildIndex == i)
            {
                bgSoundPlay(_bgms[i]);
            }

        }
    }
    public void bgmStop()
    {
        _bgmPlayer.Stop();
    }
    public void bgSoundPlay(AudioClip _clip)
    {
        _bgmPlayer.clip = _clip;
        _bgmPlayer.loop = true;
        _bgmPlayer.playOnAwake = true;
        _bgmPlayer.volume = 1f;
        _bgmPlayer.mute = false;
        _bgmPlayer.Play();
    }
    public void SFXPlay(sfx type)
    {
        switch(type)
        {
            case sfx.Click:
                _sfxPlayer[sfxIndex].clip = _sfxs[0];
                break;
            case sfx.StoneOpen:
                _sfxPlayer[sfxIndex].clip = _sfxs[1];
                break;
            case sfx.Attack:
                _sfxPlayer[sfxIndex].clip = _sfxs[2];
                break;
            case sfx.SlimeAttack:
                _sfxPlayer[sfxIndex].clip = _sfxs[3];
                break;
            case sfx.SlimeDeath:
                _sfxPlayer[sfxIndex].clip = _sfxs[4];
                break;
            case sfx.GetItem:
                _sfxPlayer[sfxIndex].clip = _sfxs[5];
                break;
            case sfx.GameOver:
                _sfxPlayer[sfxIndex].clip = _sfxs[6];
                break;
        }

        _sfxPlayer[sfxIndex].volume = 1f;
        _sfxPlayer[sfxIndex].mute = false;
        _sfxPlayer[sfxIndex].Play();
        sfxIndex=(sfxIndex+1)%_sfxPlayer.Length;
    }


}
