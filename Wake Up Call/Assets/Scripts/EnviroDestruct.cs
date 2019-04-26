using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviroDestruct : MonoBehaviour {

    public GameObject doll;
    private Collider[] ragdoll;

	// Use this for initialization
	void Start () {
        Collapse(true);
        ragdoll = doll.gameObject.GetComponentsInChildren<Collider>();
    }

    private void OnTriggerEnter(Collider ragdoll)
    {
        Collapse(false);
    }

    public void Collapse(bool newvalue)
    {
        Rigidbody[] bodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in bodies)
        {
            rb.isKinematic = true;
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}
