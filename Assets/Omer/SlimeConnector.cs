using UnityEngine;

public class SlimeConnector : MonoBehaviour
{
    public GameObject[] slimeParts; // Array of objects representing the slime
    public float springForce = 10f;
    public float damper = 2f;
    public float maxDistance = 0.5f;

    void Start()
    {
        for (int i = 0; i < slimeParts.Length - 1; i++)
        {
            SpringJoint joint = slimeParts[i].AddComponent<SpringJoint>();
            joint.connectedBody = slimeParts[i + 1].GetComponent<Rigidbody>();
            joint.spring = springForce;
            joint.damper = damper;
            joint.maxDistance = maxDistance;
        }

        // Optionally connect the last object back to the first for a loop
        SpringJoint loopJoint = slimeParts[slimeParts.Length - 1].AddComponent<SpringJoint>();
        loopJoint.connectedBody = slimeParts[0].GetComponent<Rigidbody>();
        loopJoint.spring = springForce;
        loopJoint.damper = damper;
        loopJoint.maxDistance = maxDistance;
    }
}
