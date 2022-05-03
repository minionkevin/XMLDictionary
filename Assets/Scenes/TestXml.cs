using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;


public class TestDic
{
    public int testNum;
    public Serialize<int, string> dic;
}


public class TestXml : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string path = Application.persistentDataPath + "/Test.xml";
        TestDic tester = new TestDic();

        
        //Ser
        tester.testNum = 2333;
        tester.dic = new Serialize<int, string>();
        tester.dic.Add(1, "Kevin");
        tester.dic.Add(2, "Betty");
        tester.dic.Add(3, "Game Programmer");

        using (StreamWriter w = new StreamWriter(path))
        {
            XmlSerializer s = new XmlSerializer(typeof(TestDic));
            s.Serialize(w, tester);
        }

        //De
        using (StreamReader reader = new StreamReader(path))
        {
            XmlSerializer s = new XmlSerializer(typeof(TestDic));
            tester = s.Deserialize(reader) as TestDic;   
        }

        //print out
       foreach(KeyValuePair<int,string> pair in tester.dic)
       {
            Debug.Log(pair.Key + " " + pair.Value);
       }
    }
}
