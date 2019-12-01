using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{

    public GameObject myHand;
    public GameObject ball;
    public float throwPower;

    bool inHands = false;
    Vector3 ballPosition;

    Collider ballColider;
    Rigidbody ballRigidbody;

    Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        ballPosition = ball.transform.position;
        ballColider = ball.GetComponent<SphereCollider>();
        ballRigidbody = ball.GetComponent<Rigidbody>();
        camera = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            if (!inHands) {
                ballColider.isTrigger = true;
                ball.transform.SetParent(myHand.transform);
                ball.transform.localPosition = new Vector3(0f, -0.63f, 0f);
                ballRigidbody.velocity = Vector3.zero;
                ballRigidbody.useGravity = false;
                inHands = true;
            } else {
                ballColider.isTrigger = false;
                ballRigidbody.useGravity = true;
                this.GetComponent<PlayerGrab>().enabled = false;
                ball.transform.SetParent(null);
                ballRigidbody.velocity = camera.transform.rotation * Vector3.forward * throwPower;
                inHands = false;
            }
        }
    }
}
