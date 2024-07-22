using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using UnityEngine;

using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]

public class PlayersDataManager : MonoBehaviour
{
    

    [System.Serializable]
    public struct playerData
    {
        public string name;
        public int level;
        public float x, y, z;

        public Vector3 getVector3()
        {
            return new Vector3(x, y, z);
        }
        public void setVector3(Vector3 v)
        {
            x = v.x;
            y = v.y;
            z = v.z;
        }
    }
    public List<playerData> allPlayers;
   
    [HideInInspector]
    public bool loaded;
    public void Awake()
    {
        loaded = true;
    }

    public void nullList()
    {
        allPlayers = new List<playerData>(0);
    }

    void Start()
    {
        //LoadFunc();
    }

    public void SaveFuncOld() //not using
    {

        Debug.Log(Application.persistentDataPath);

        // Stream the file with a File Stream. (Note that File.Create() 'Creates' or 'Overwrites' a file.)
        FileStream file = File.Create(Application.persistentDataPath + "/PlayerData.dat");
        // Create a new Player_Data.
        //Player_Data data = new Player_Data();
        //playerData[] data = new Player_Data();
        //playerData[] data = allPlayers;
        List<playerData> data = allPlayers;

        //Save the data.

        //Serialize to xml
        DataContractSerializer bf = new DataContractSerializer(data.GetType());
        MemoryStream streamer = new MemoryStream();

        //Serialize the file
        bf.WriteObject(streamer, data);
        streamer.Seek(0, SeekOrigin.Begin);

        //Save to disk
        file.Write(streamer.GetBuffer(), 0, streamer.GetBuffer().Length);

        // Close the file to prevent any corruptions
        file.Close();

        string result = XElement.Parse(Encoding.ASCII.GetString(streamer.GetBuffer()).Replace("\0", "")).ToString();
        Debug.Log("Serialized Result: " + result);

    }

    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/PlayerData.dat");
        List<playerData> data = allPlayers;
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Game Saved");
    }
   

    public void LoadFunc()
    {
        if (File.Exists(Application.persistentDataPath + "/PlayerData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/PlayerData.dat", FileMode.Open);
            allPlayers = (List<playerData>)bf.Deserialize(file);
            file.Close();
            Debug.Log("Game Loaded");
        }
        else
        {
            Debug.Log("No game saved!");
        }
        loaded = true;
    }
  


}
