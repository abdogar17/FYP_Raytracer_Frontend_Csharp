using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
[XmlRoot("ActorDataColloction")]
public class ActorDataColloction : MonoBehaviour
{
   

   

    [XmlArray("Actor")]
    [XmlArrayItem("Actors")]
    public List<ActorData> Actors = new List<ActorData>();

}
