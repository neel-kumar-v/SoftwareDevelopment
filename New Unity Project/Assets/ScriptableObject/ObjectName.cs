using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ObjectName", order = 1)]
public class ObjectName : ScriptableObject
{
    public GameObject obj;
    public string objectName;
    public Vector3 pos = new Vector3(-45.2f,-7.5f,-0.12f);
}
