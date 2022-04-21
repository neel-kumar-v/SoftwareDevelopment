using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlaceNew : MonoBehaviour
{
    public Button buttonSphere;
    public Button buttonCube;
    public GameObject sphere;
    public GameObject cube;

    private Vector3 placedPos;
    public MousePosition mousePosition;
    public Transform holder;

    // Start is called before the first frame update
    void Start()
    {
        mousePosition = GetComponent<MousePosition>();
    }

    // Update is called once per frame
    void Update()
    {
        placedPos = mousePosition.GetMousePosition(sphere, false);


    }
    public void PlaceCube() {
        GameObject newCube = Instantiate(cube, holder, false);
    }

    public void PlaceSphere() {
        GameObject newSphere = Instantiate(sphere, holder, false);
    }
}
