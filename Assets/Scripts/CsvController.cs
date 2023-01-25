using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions; //Regex.Split
using UnityEngine;
using UnityEngine.Playables;

public class CsvController : MonoBehaviour
{
        public List<stHeroData> IstHero = new List<stHeroData>();
    // Start is called before the first frame update
    void Start()
    {
        ReadFile();
        //WriteFile();

    }

    void WriteFile()
    {
        string FileName = "saveFile" + DateTime.Now.ToString("yyMMddHHmmss") + ".csv"; // Now 현재시간

        string delimiter = ",";
        List<string[]> lists = new List<string[]>();

        string[] datas = new string[] { "Name", "Time", "Stage", "Exp" };
        lists.Add(datas);
        string[] value1 = new string[] { "p1", DateTime.Now.ToString(), "15", "54546" };
        lists.Add(value1);
        string[] value2 = new string[] { "p2", DateTime.Now.ToString(), "5", "544" };
        lists.Add(value2);

        string[][] outPuts = lists.ToArray();
        StringBuilder sb = new StringBuilder();
        for(int i=0;i<outPuts.Length;i++)
        {
           sb.AppendLine(string.Join(delimiter, outPuts[i]));
        }

        string filepath = Application.dataPath + "/Resources/Datas/" + FileName;

        using (StreamWriter outStream = File.CreateText(filepath))
        {
            outStream.Write(sb);
        }
    }

    void ReadFile()
    {
        string path = Application.dataPath + "/Resources/Datas/Source.csv";
        Debug.Log(File.Exists(path));
        
        if(File.Exists(path))
        {
            string source;
            using (StreamReader sr = new StreamReader(path))  //
            {
                string[] lines;
                source= sr.ReadToEnd();
                lines = Regex.Split(source, @"\r\n|\n\r|\n|\r"); //Regex.Split(문자열 잘라줌,@'식');
                string[] header = Regex.Split(lines[0], ","); //0번째줄 ","기준으로 잘라줌
                for(int i=1; i<lines.Length; i++)
                {
                    string[] values = Regex.Split(lines[i], ",");
                    if (values.Length == 0 || string.IsNullOrEmpty(values[0])) continue;
                    
                    stHeroData tempData = new stHeroData();
                    tempData.INDEX = int.Parse(values[0]);
                    tempData.NAME = values[1];
                    tempData.EXP = int.Parse(values[2]);
                    tempData.LEVEL =int.Parse( values[3]);
                    tempData.MOVESPEED = float.Parse(values[4]);
                    tempData.ATTACKPOWER = int.Parse(values[5]);

                    IstHero.Add(tempData);

                 
                    
                    //int j = 0;
                   //foreach(string data in values)
                   // {

                   //     Debug.Log(i+"행의"+j+"번째 데이터는"+data+"입니다.");
                   //     j++;
                    
                   // }
                    
                    // Debug.Log(string.Join(",", values)); //
                }
                //while((source=sr.ReadLine()) !=null) // ReadLine 한 라인씩 읽어줌
                //{

                //}

                //source = sr.ReadToEnd(); //ReadToEnd 파일 끝까지 읽어줌
                //Debug.Log(source);


            }
        }

        foreach(stHeroData data in IstHero)
        {
            Debug.Log(data.NAME + "," + data.LEVEL);
        }
    }
}

public struct stHeroData
{
    public int INDEX;
    public string NAME;
    public int EXP;
    public int LEVEL;
    public float MOVESPEED;
    public int ATTACKPOWER;

}
