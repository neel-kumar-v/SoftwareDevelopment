using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialManager : MonoBehaviour
{
    [Header("Cube Attributes")]
    [SerializeField] private GameObject cube;
    private Material cubeMat;
    [SerializeField] private Renderer cubeRenderer;
    [SerializeField] private BoxCollider cubeCollider;
    [SerializeField] private Dropdown cubeDrop;
    private string cubeText;

    [Header("Base Attributes")]
    [SerializeField] private GameObject baseObj;
    private Material baseMat;
    [SerializeField] private Renderer baseRenderer;
    [SerializeField] private BoxCollider baseCollider;
    [SerializeField] private Dropdown baseDrop;
    private string baseText;

    [Space(10)]
    public MaterialName[] materials;
    public PhysicsMaterialName[] physicsMaterials;

    // Delete later
    [SerializeField] private Text textCube;
    [SerializeField] private Text textBase;

    [SerializeField] private Slider dynamicFriction;
    [SerializeField] private Slider staticFriction;
    [SerializeField] private Text dynamicText;
    [SerializeField] private Text staticText;


    // Start is called before the first frame update
    void Start()
    {
        // Properly sets the cube position
        cube.transform.position = new Vector3(-47.25f, -5.5f, 0f);
        // Shows the materials of both objects
        cubeMat = cubeRenderer.material;
        baseMat = baseRenderer.material;
    }

    // Update is called once per frame
    public void Update()
    {
        // Debug text update
        textCube.text = cubeDrop.captionText.text;
        textBase.text = baseDrop.captionText.text;

        // captionText  is the currently selected option of the dropdown
        cubeText = cubeDrop.captionText.text;
        baseText = baseDrop.captionText.text;


        foreach(MaterialName material in materials) { // Iterates through the array of materials and their respective names
            if(material.materialName == cubeText) {
                cubeRenderer.material = material.material;
            }
            if(material.materialName == baseText) {
                baseRenderer.material = material.material;
            }
        }

        string physicsText = cubeText + " - " + baseText; 

        foreach(PhysicsMaterialName physicsMaterial in physicsMaterials) {// Iterates through the array of physics materials and their respective names
            // Since Ice - Wood and Wood - Ice end up with the same physic material result, we need to check for both 
            if(physicsMaterial.materialName == physicsText || physicsMaterial.materialNameReversed == physicsText) {
                cubeCollider.material = physicsMaterial.material;
                baseCollider.material = physicsMaterial.material;

                UpdateSliderValue(physicsMaterial.material.dynamicFriction, dynamicFriction);
                UpdateFrictionValue(physicsMaterial.material.dynamicFriction, dynamicText);

                UpdateSliderValue(physicsMaterial.material.staticFriction, staticFriction);
                UpdateFrictionValue(physicsMaterial.material.staticFriction, staticText);
            }
        }
    }

    public void UpdateSliderValue(float friction, Slider slider) {
        if(friction != slider.value) {
            slider.value = Mathf.Lerp(slider.value, friction, 5 * Time.deltaTime); // Lerp makes the bar move smoothly
        }
    }

    public void UpdateFrictionValue(float friction, Text text) {
        // Tried to make a smoothly transitioning tezt, but it didn't work
            // if(Mathf.Abs(friction - float.Parse(text.text)) <= 0.01f) return;
            // if(friction != float.Parse(text.text)) {
            //     text.text = Mathf.Lerp(float.Parse(text.text), friction, 5f * Time.deltaTime).ToString("0.00");
            // } 
        text.text = friction.ToString("0.00");
    }


}
