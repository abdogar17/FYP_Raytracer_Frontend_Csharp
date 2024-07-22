using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;
using System.Xml;

[System.Serializable]
public class PlayersLoader : MonoBehaviour
{
    public PlayersDataManager PDM;

    public GameObject[] RoomObj;

    public Transform ObjectHolder;
    public static PlayersLoader Instance;
    string filename;
    private void Awake()
    {
        Instance = this;
    }
    GameObject temp, NewMonster;
    private IEnumerator Start()
    {
        yield return null /*WaitUntil(() => PDM.loaded)*/;
        LoadFuncByXml();
        //load

        for (int i = 0; i < PDM.allPlayers.Count; i++)
        {
            PlayersDataManager.playerData current = PDM.allPlayers[i];

                temp = Instantiate(RoomObj[current.level], ObjectHolder);
                temp.transform.position = current.getVector3();
                temp.SetActive(true);
                temp.GetComponent<DRAGGING>().Name = current.name;
                temp.GetComponent<DRAGGING>().Type = current.level;
        }
    }

    public void save()
    {
        PDM.nullList();
        for (int i = 0; i < ObjectHolder.childCount; i++)
        {
            PlayersDataManager.playerData newPlayer = new PlayersDataManager.playerData();

            DRAGGING df = ObjectHolder.GetChild(i).GetComponent<DRAGGING>();

            newPlayer.name = df.Name;

            newPlayer.level = df.Type;

            newPlayer.setVector3(ObjectHolder.GetChild(i).transform.position);
            
            PDM.allPlayers.Add(newPlayer);
        }

        PDM.SaveGame();
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.L))
        {
            SaveGameByXMl();
        }
    }

    private void OnApplicationQuit()
    {
        SaveGameByXMl();
    }

    public void SaveGameByXMl()
    {
        DRAGGING Save = createSaveObject();
        XmlDocument xmlDocument = new XmlDocument();

        XmlElement root = xmlDocument.CreateElement("Save");
        root.SetAttribute("FileName", "File01");

        //XmlElement ObjectPosType = xmlDocument.CreateElement("ObjectType");
        //ObjectPosType.InnerText = Save.Type.ToString();

        //XmlElement ObjectPosX = xmlDocument.CreateElement("ObjectPosX");
        //ObjectPosX.InnerText = Save.transform.position.x.ToString();
        //XmlElement ObjectPosY = xmlDocument.CreateElement("ObjectPosY");
        //ObjectPosY.InnerText = Save.transform.position.y.ToString();

        //XmlElement ObjectPosZ = xmlDocument.CreateElement("ObjectPosZ");
        //ObjectPosZ.InnerText = Save.transform.position.z.ToString();

        Debug.Log(Application.dataPath);

        XmlElement ObjectPosZ,Roomobject, ObjectPosType, ObjectPosY, ObjectPosX;
        for (int i = 0; i < ObjectHolder.childCount; i++)
        {
            Roomobject = xmlDocument.CreateElement("player");
            ObjectPosType = xmlDocument.CreateElement("ObjectType");
            ObjectPosX = xmlDocument.CreateElement("ObjectPosX");
            ObjectPosY = xmlDocument.CreateElement("ObjectPosY");
            ObjectPosZ = xmlDocument.CreateElement("ObjectPosZ");



            ObjectPosType.InnerText = Save.Type.ToString();
            ObjectPosX.InnerText = Save.transform.position.x.ToString();
            ObjectPosY.InnerText = Save.transform.position.y.ToString();
            ObjectPosZ.InnerText = Save.transform.position.z.ToString();

            Roomobject.AppendChild(ObjectPosType);
            Roomobject.AppendChild(ObjectPosX);
            Roomobject.AppendChild(ObjectPosY);
            Roomobject.AppendChild(ObjectPosZ);

            root.AppendChild(Roomobject);
        }
        if (root != null)
        {
        xmlDocument.Save(Application.dataPath + "/DataXML.xml");

        if (File.Exists(Application.dataPath + "/DataXML.xml"))
        {
            Debug.Log("Game Saved");
        }
        else
        {
            Debug.Log("Not Game Saved");
        }

        }

       
    }

    public void LoadDAta()
    {
       
    }
    public void LoadFuncByXml()
    {
        if (File.Exists(Application.dataPath + "/DataXML.xml"))
        {

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(Application.dataPath + "/DataXML.xml");

            XmlNodeList Roomobject = xmlDocument.GetElementsByTagName("player");
            if (Roomobject.Count!=0)
            {
                for (int i = 0; i < Roomobject.Count; i++)
                {
                    XmlNodeList ObjectPosType = xmlDocument.GetElementsByTagName("ObjectType");
                    int PlayerType = int.Parse(ObjectPosType[i].InnerText);


                    XmlNodeList ObjectPosX = xmlDocument.GetElementsByTagName("ObjectPosX");
                    float PlayerposX = float.Parse(ObjectPosX[i].InnerText);


                    XmlNodeList ObjectPosY = xmlDocument.GetElementsByTagName("ObjectPosY");
                    float PlayerposY = float.Parse(ObjectPosY[i].InnerText);

                    XmlNodeList ObjectPosZ = xmlDocument.GetElementsByTagName("ObjectPosZ");
                    float PlayerposZ = float.Parse(ObjectPosZ[i].InnerText);


                    PlayersDataManager.playerData current = PDM.allPlayers[i];

                    current.level= PlayerType;
                    current.x= PlayerposX;
                    current.y = PlayerType;
                    current.z = PlayerposX;
                }
            }
        }
        else
        {
            //Debug.Log("File Not found");
        }
    }


    int Temp = 0;
    public DRAGGING createSaveObject()
    {
        DRAGGING Drag = ObjectHolder.GetChild(0).GetComponent<DRAGGING>();
        Temp++;
        return Drag;
    }

}
