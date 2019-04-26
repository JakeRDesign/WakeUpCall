using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClutterUp : MonoBehaviour {

    public Transform hand;
    private bool up;

    public float speed = 10;

    public ReactionController other;

    private void Start()
    {
        up = false;
    }

    private void Update()
    {
        if (up == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                gameObject.transform.parent = null;
                GetComponent<Rigidbody>().AddForce(0, 0, -speed, ForceMode.Impulse);
                GetComponent<Rigidbody>().useGravity = true;
                Invoke("ResetPick", 0.1f);
            }
        }
    }

    private void OnMouseOver()
    {
        if (up == false)
        {
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                GetComponent<Rigidbody>().useGravity = false;
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                gameObject.transform.position = hand.position;
                gameObject.transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
                up = true;
            }
        }
    }

    void ResetPick()
    {
        up = false;
    }

    // When object hits a rigidbody, ragdoll is activated.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody)
        {
            other.Knockback();
        }
    }
}
