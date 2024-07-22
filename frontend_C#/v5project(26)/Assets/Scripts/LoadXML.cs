using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

public class LoadXML : MonoBehaviour
{
    public TextAsset GameAsset;

    static string Bed1 = "";
    static string Chair1 = "";

    List<Dictionary<string,string>> levels = new List<Dictionary<string,string>>();
    Dictionary<string,string> obj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

 public void GetLevel()
 {
  XmlDocument xmlDoc = new XmlDocument(); // xmlDoc is the new xml document.
  xmlDoc.LoadXml(GameAsset.text); // load the file.
  XmlNodeList levelsList = xmlDoc.GetElementsByTagName("Item"); // array of the level nodes.
 
  foreach (XmlNode levelInfo in levelsList)
  {
   XmlNodeList levelcontent = levelInfo.ChildNodes;
   obj = new Dictionary<string,string>(); // Create a object(Dictionary) to colect the both nodes inside the level node and then put into levels[] array.
   
   foreach (XmlNode levelsItens in levelcontent) // levels itens nodes.
   {
    if(levelsItens.Name == "name")
    {
     obj.Add("name",levelsItens.InnerText); // put this in the dictionary.
    }
   
    if(levelsItens.Name == "x")
    {
     obj.Add("x",levelsItens.InnerText); // put this in the dictionary.
    }

    if(levelsItens.Name == "y")
    {
     obj.Add("y",levelsItens.InnerText); // put this in the dictionary.
    }
    if(levelsItens.Name == "z")
    {
     obj.Add("z",levelsItens.InnerText); // put this in the dictionary.
    }
   
   }
   levels.Add(obj); // add whole obj dictionary in the levels[].
  }
  
}
}

