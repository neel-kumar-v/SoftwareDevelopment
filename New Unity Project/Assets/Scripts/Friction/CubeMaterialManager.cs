using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeMaterialManager : MonoBehaviour
{
    // Array of all materials and their names
    public MaterialName[] materialsToChooseFrom;
    // The cube and the floor
    public GameObject cube;
    // Called baseObj not base bc base gave an error
    public GameObject baseObject;

    // Which number of the array is the cube and base currently at
    [HideInInspector]
    public int currentCubeMaterialIndex;
    [HideInInspector]
    public int currentBaseMaterialIndex;

    [HideInInspector]
    public Material cubeMaterial;
    [HideInInspector]
    public Material baseMaterial;

    // Runs before start, not really needed but i like it
    void Awake() {
        // Finds current material for future editing
        cubeMaterial = cube.GetComponent<MeshRenderer>().material;
        baseMaterial = baseObject.GetComponent<MeshRenderer>().material;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentCubeMaterialIndex = 0;
        currentBaseMaterialIndex = 0;
        
    }

    void Update() {
        cubeMaterial = materialsToChooseFrom[currentCubeMaterialIndex].material;
        baseMaterial = materialsToChooseFrom[currentBaseMaterialIndex].material;
    }


    public void SwitchCubeMaterialLeft() {
        currentCubeMaterialIndex--;
    }

    public void SwitchCubeMaterialRight() {
        currentCubeMaterialIndex++;
    }

    public void SwitchBaseMaterialLeft() {
        currentBaseMaterialIndex--;
    }

    public void SwitchBaseMaterialRight() {
        currentBaseMaterialIndex++;
    }
}
