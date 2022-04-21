// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class IncreaseSize : MonoBehaviour
// {
//     float[] pos;
//     public Button button;

//     // Update is called once per frame
//     void Increase()
//     {
//         transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1f, 1f), 0.1f);
//         imageContent.transform.GetChild(i).localScale = Vector2.Lerp(imageContent.transform.GetChild(i).localScale, new Vector2(1.2f, 1.2f), 0.1f);
//         imageContent.transform.GetChild(i).GetComponent<Image>().color = colors[1];
//     }
    
//     void Decrease()
//     {
//         imageContent.transform.GetChild(j).GetComponent<Image>().color = colors[0];
//         imageContent.transform.GetChild(j).localScale = Vector2.Lerp(imageContent.transform.GetChild(j).localScale, new Vector2(0.8f, 0.8f), 0.1f);
//         transform.GetChild(j).localScale = Vector2.Lerp(transform.GetChild(j).localScale, new Vector2(0.8f, 0.8f), 0.1f);
//     }
// }
