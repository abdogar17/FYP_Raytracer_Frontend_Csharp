using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Button Loadbtn, saveBtn;
    public const string Playerpath="player";
    public  string datapath="";
    private void Awake()
    {
        if (Application.platform==RuntimePlatform.IPhonePlayer)
        {
            datapath = Path.Combine(Application.persistentDataPath, "Resources/Actor.text");

        }
        else
        {
            datapath = Path.Combine(Application.dataPath, "Resources/Actor.text");

        }
    }
    private void Start()
    {
        CreaterData(Playerpath, Vector3.zero, Quaternion.identity);
    }
    public static Actor CreaterData(string path,Vector3 pos,Quaternion Rot)
    {
        GameObject prefab = Resources.Load<GameObject>(path);
        GameObject go = Instantiate(prefab, pos, Rot) as GameObject;
       Actor actor=    go.GetComponent<Actor>();
        return actor;
    }

    public static Actor CreaterData(ActorData data,string path, Vector3 pos, Quaternion Rot)
    {
        GameObject prefab = Resources.Load<GameObject>(path);
        GameObject go = Instantiate(prefab, pos, Rot) as GameObject;
        Actor actor = go.GetComponent<Actor>();
        actor.actorData = data;
        return actor;
    }
    private void OnEnable()
    {
        saveBtn.onClick.AddListener(delegate { DataSaver.SAveData(datapath, DataSaver.ActorContainer); });
        Loadbtn.onClick.AddListener(delegate { DataSaver.Load(datapath); });
    }
    private void OnDisable()
    {

        saveBtn.onClick.RemoveListener(delegate { DataSaver.SAveData(datapath, DataSaver.ActorContainer); });
        Loadbtn.onClick.RemoveListener(delegate { DataSaver.Load(datapath); });
    }
}
