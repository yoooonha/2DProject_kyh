using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PathTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();

        //PlayerPrefs.SetFloat("soundVolume", 0.5f);
        //PlayerPrefs.SetString("userName", "영웅");
        //PlayerPrefs.SetInt("userID", 955);



        float soundvolume = PlayerPrefs.GetFloat("soundVolume");
        Debug.Log(soundvolume);

        string userName = PlayerPrefs.GetString("userName");
        Debug.Log(userName);



        int userid = PlayerPrefs.GetInt("userID");
        Debug.Log(userid);

       // Debug.Log("dataPath :" + Application.dataPath); //읽기전용
       // Debug.Log("persistenPath :" + Application.persistentDataPath); //cash file

       // Debug.Log(Directory.Exists(Application.persistentDataPath + "/datas"));

       //if(! Directory.Exists(Application.persistentDataPath+"/user00"))
       // {
       //     Directory.CreateDirectory(Application.persistentDataPath + "/user00");

       // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
