using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    private float cycleInterval = 0.01f;

    private List<ChargedParticle> chargedParticles;
    private List<MovingChargedParticle> movingChargedParticles;

    // Start is called before the first frame update
    void Start()
    {
        chargedParticles = new List<ChargedParticle> (FindObjectsOfType<ChargedParticle> ());
        movingChargedParticles = new List<MovingChargedParticle> (FindObjectsOfType<MovingChargedParticle> ());

        foreach(MovingChargedParticle mcp in movingChargedParticles) {
            StartCoroutine (Cycle (mcp));
        }
    }

    public IEnumerator Cycle(MovingChargedParticle mcp) {
        bool isFirst = true;
        while(true) {

            if (isFirst) {
                isFirst = false;
                yield return new WaitForSeconds(Random.Range(0, cycleInterval));
            }
            ApplyMagneticForce(mcp);
            yield return new WaitForSeconds(cycleInterval);
        }
    }

    private void ApplyMagneticForce(MovingChargedParticle mcp) {
        Vector3 newForce = Vector3.zero;

        foreach(ChargedParticle cp in chargedParticles) {
            if (mcp == cp) {
                continue;
            }

            float distance = Vector3.Distance(mcp.transform.position, cp.gameObject.transform.position);
            float force = 1000*mcp.charge*cp.charge/Mathf.Pow(distance, 2);

            Vector3 direction = mcp.transform.position - cp.transform.position;
            direction.Normalize();

            newForce += force*direction*cycleInterval;

            if(float.IsNaN(newForce.x)) {
                newForce = Vector3.zero;
            }

            mcp.rb.AddForce(newForce);
        }
    }
}
