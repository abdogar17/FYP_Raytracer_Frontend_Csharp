using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
public class Actor : MonoBehaviour
{
    public ActorData actorData = new ActorData();

    public string name = "";

    public int Id;
  public void StoreData()
  {
        actorData.Name = name;
        Vector3 DemoPos = transform.position;
        actorData.PosX = DemoPos.x;
        actorData.PosZ = DemoPos.z;
        actorData.PosY = DemoPos.y;

        Quaternion DemoRot = transform.rotation;
        actorData.RotW = DemoRot.w;
        actorData.RotZ = DemoRot.z;
        actorData.RotY = DemoRot.y;
        actorData.RotX = DemoRot.x;
  }
    private void OnEnable()
    {
        DataSaver.onLoad += delegate { LoadData(); };
        DataSaver.beForeSave += delegate {StoreData(); };
        DataSaver.beForeSave += delegate {DataSaver.AddActorData(actorData); };

    }
    private void OnDisable()
    {
        DataSaver.onLoad -= delegate { LoadData(); };
        DataSaver.beForeSave -= delegate { StoreData(); };
        DataSaver.beForeSave -= delegate { DataSaver.AddActorData(actorData); };

    }
    public void LoadData()
    {
        transform.position = new Vector3(actorData.PosX, actorData.PosY, actorData.PosZ);
        transform.rotation = new Quaternion(actorData.RotX, actorData.RotY, actorData.RotZ,actorData.PosX);
    }
}
public class ActorData
{
    [XmlAttribute("Name")]
    public string Name;
    
    [XmlElement("id")]
    public int Id;

    [XmlElement("Posx")]
    public float PosX;
    [XmlElement("PosY")]
    public float PosY;
    [XmlElement("PosZ")]
    public float  PosZ;



    [XmlElement("RotX")]

    public float RotX;
    [XmlElement("RotY")]

    public float RotY;
    [XmlElement("RotZ")]

    public float RotZ;
    [XmlElement("RotW")]

    public float RotW;
   
}
