using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Collections;
using System.Xml.Serialization;
using System.Collections.Generic;
using UnityEngine.UI;

public class InstantiationExample : MonoBehaviour
{
    //private int i = 0;
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject myPrefab , clone;
    
    public static ItemContainer Items = new ItemContainer();
    public string name = "object";

    [SerializeField] private string DestroyTag = "Undestroyable";

    //public Item item = new Item();

    //private static string path = "";

   /* void Awake()
    {
       *//* if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            dataPath = System.IO.Path.Combine(Application.persistentDataPath, "Resources/objects.xml");
        }
        else
        {
            dataPath = System.IO.Path.Combine(Application.dataPath, "Resources/objects.xml");
        }*//*
       path = Application.dataPath + "/resources/objects.xml";
    }*/

    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        
    }

    void Update(){
        if(Input.GetMouseButtonDown(2)){
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray , out hit)){
                BoxCollider bc = hit.collider as BoxCollider;
                if(bc != null && !bc.gameObject.CompareTag(DestroyTag)){
                    Destroy(bc.gameObject);
                }
            }
        }
    }

    

    public void ShowObj(GameObject obj)
    {
        // Instantiate at position (0, 0, 0) and zero rotation.
        // GameObject gb = new GameObject();
        // gb.name = "Obj " + i++;
        // gb.transform.position = new Vector3(0,0,0);
        // gb.transform.rotation = Quaternion.identity;
        clone = Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        
    }
    
    public void HideObj(GameObject obj)
    {
        //Destroy(clone, 0.1f);
        
    }

    public void GetPos()
    {
        if(clone != null){
        Vector3 pos = clone.transform.position;
        Quaternion rot = clone.transform.rotation;
        // Debug.Log("Co-ord = " + pos);
        float x = pos.x , y = pos.y , z = pos.z;
        float rx = rot.x, ry = rot.y, rz = rot.z;

        //myPrefab = PrefabUtility.GetCorrespondingObjectFromSource(clone);
        string n = name; //myPrefab.name;

        Item i = new Item();
        i.name = n;
        i.x = x; i.y = y; i.z = z;
        i.rx = rx; i.ry = ry; i.rz = rz;

        Items.items.Add(i);
        SaveObjects();
        }
    }

    public static void SaveObjects()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(ItemContainer));

        FileStream stream = new FileStream(Application.dataPath + "/Scripts/objects.xml", FileMode.Create);

        serializer.Serialize(stream, Items);

        stream.Close();
    }
}

[System.Serializable]
public class Item
{
    public string name; 
    public float x , y , z;
    public float rx , ry , rz;

}

[System.Serializable]
public class ItemContainer
{
    [XmlArray("Objects")]

    public List<Item> items = new List<Item>();
}
