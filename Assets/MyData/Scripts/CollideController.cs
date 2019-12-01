using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollideController : MonoBehaviour
{
    public int score = 0;

    public Text scoreText;
    public GameObject ball;
    
    void Update()
    {
        // Debug.Log(ballRigidbody.velocity);
        if (ball.transform.position.y < -10.0f) {
            RandomBallPosition();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            score++;
            scoreText.text = "Score: " + score;
            
            // GameObject ball = other.gameObject;
            RandomBallPosition();

        }
    }

    private void RandomBallPosition()
    {
        Collider ballColider = ball.GetComponent<SphereCollider>();
        Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();

        ball.transform.SetParent(null);
        ball.transform.localPosition = new Vector3(GetRandomPosition(), 0.4f, GetRandomPosition());
        ballColider.isTrigger = false;
        ballRigidbody.useGravity = true;
        ballRigidbody.velocity = Vector3.zero;
        ballRigidbody.angularVelocity = Vector3.zero;
    }

    private float GetRandomPosition() {
        return (Random.value * 20.0f) - 10.0f;
    }
}
