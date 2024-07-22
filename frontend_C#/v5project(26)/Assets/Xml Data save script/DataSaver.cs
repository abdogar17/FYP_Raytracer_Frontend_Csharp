using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System .Xml.Serialization;
using System.IO;

public class DataSaver : MonoBehaviour
{
    public static ActorDataColloction ActorContainer = new ActorDataColloction();
    public delegate void SerializeAction();
    public static event SerializeAction onLoad;
    public static event SerializeAction beForeSave;
    // Start is called before the first frame update
    void Start()
    {

    }
    public static void Load(string path)
    {
        ActorContainer = LoadActor(path);
        foreach (ActorData data in ActorContainer.Actors)
        {
            PlayerController.CreaterData( data, PlayerController.Playerpath, Vector3.zero, Quaternion.identity);
        }
        onLoad();
    }

    public static void SAveData(string path, ActorDataColloction actors)
    {
        beForeSave();
        SaveActor(path, actors);
        //ClearData();
    }

    public static void AddActorData(ActorData data)
    {
        ActorContainer.Actors.Add(data);

    }
    public static void ClearData()
    {
        ActorContainer.Actors.Clear();
    } 
    public static ActorDataColloction LoadActor(string path)
    {

        XmlSerializer serializer = new XmlSerializer(typeof(ActorDataColloction));
        FileStream stream = new FileStream(path, FileMode.Open);
        ActorDataColloction actors = serializer.Deserialize(stream) as ActorDataColloction;
        stream.Close();
        return actors;
    }
    public  static void SaveActor(string path,ActorDataColloction actors)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(ActorDataColloction));
        FileStream stream = new FileStream(path,FileMode.OpenOrCreate);
        serializer.Serialize(stream, actors);
        stream.Close();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
