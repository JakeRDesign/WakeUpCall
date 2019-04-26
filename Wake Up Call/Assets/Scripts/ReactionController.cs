using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactionController : MonoBehaviour {

    public Collider[] proj;  

	// Use this for initialization
	void Start () {
        SetKinematic(true);
	}
	
	// Update is called once per frame
	void Update () {
        //  Testing. The Ragdoll function was working, but not on hit.
		//if (Input.GetKey(KeyCode.Space))
        //{
        //   Knockback();
        //}
	}

    void SetKinematic(bool newvalue)
    {
        Rigidbody[] bodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in bodies)
        {
            rb.isKinematic = newvalue;
        }
    }

    //private void OnTriggerEnter(Collider proj)
    //{
    //    Knockback();
    //}

    public void Knockback()
    {
        SetKinematic(false);
        GetComponent<Animator>().enabled = false;
        Rigidbody[] bodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in bodies)
        {
            rb.AddRelativeForce(Vector3.back * 200);
        }
        Destroy(gameObject, 5f);
    }
}
