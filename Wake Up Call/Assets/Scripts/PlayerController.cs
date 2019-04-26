using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 0.002f;

    private Rigidbody pc;

    // Use this for initialization
    void Start () {
        pc = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.W))
            //transform.localPosition = transform.localPosition + new Vector3(0, 0, -.03f);
            //pc.velocity += Vector3.back * Time.deltaTime;
            transform.position = transform.localPosition + Vector3.back * speed;

        if (Input.GetKey(KeyCode.S))
            //transform.localPosition = transform.localPosition + new Vector3(0, 0, .03f);
            transform.position = transform.localPosition + Vector3.forward * speed;

        if (Input.GetKey(KeyCode.A))
            //transform.localPosition = transform.localPosition + new Vector3(.03f, 0, 0);
            transform.position = transform.localPosition + Vector3.right * speed;

        if (Input.GetKey(KeyCode.D))
            //transform.localPosition = transform.localPosition + new Vector3(-.03f, 0, 0);
            transform.position = transform.localPosition + Vector3.left * speed;
    }
}
