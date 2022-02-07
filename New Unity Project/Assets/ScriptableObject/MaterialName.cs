using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/MaterialName", order = 1)]
public class MaterialName : ScriptableObject
{
    public Material material;
    public string materialName;
}
