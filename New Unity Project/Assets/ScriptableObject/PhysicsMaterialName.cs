using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PhysicsMaterialName", order = 1)]
public class PhysicsMaterialName : ScriptableObject
{
    public PhysicMaterial material;
    public string materialName;
    public string materialNameReversed;
}
