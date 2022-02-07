using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForceUIManager : MonoBehaviour
{
    [SerializeField] private Text summary;
    [SerializeField] private Text forceInput;
    [SerializeField] private Dropdown objectInput;
    

    public static float _force;
    public static float _acceleration;

    private string oName;
    private string mass;
    private string force;
    private string acceleration;



    private WaitForSeconds timeInSeconds;

    public void Awake() {
        timeInSeconds = new WaitForSeconds(0.5f);
    }

    public void Start() {
        force = acceleration = "TBD";

    }

    public void Update()
    {
        Name();
        Mass();
        summary.text = "A <b>" + oName + "</b> with a mass of <b>" + mass + "</b> was given a force of <b>" + force + "</b>, resulting in an acceleration of <b>" + acceleration + "</b>";
    }


    public void Name() {
        oName = objectInput.captionText.text;
    }

    public void DisplayForce() {
        if(forceInput.text == "") {
            force = "TBD";
            return;
        }
        _force = float.Parse(forceInput.text);
        force = forceInput.text + "N";
    }

    public void Mass() {
        if(SwitchObject.rb == null) {
            mass = "TBD";
            return;
        }
        mass = RoundMass(SwitchObject.rb.mass).ToString() + "kg";
    }
    public float RoundMass(float mass) {
        mass *= 10f;
        mass = Mathf.Ceil(mass);
        mass *= 0.1f;
        return mass;
    }

    public void DisplaySpeed() {
        StartCoroutine(DisplaySpeedCoroutine());
    }

    public IEnumerator DisplaySpeedCoroutine() {
        yield return timeInSeconds;
        if(SwitchObject.rb == null || SwitchObject.rb.velocity.magnitude < 1f) {
            acceleration = "TBD";
            yield return null;
        };
        float _acceleration = Mathf.Ceil(_force / SwitchObject.rb.mass);
        acceleration = _acceleration.ToString() + "m/s²";
    }




}
