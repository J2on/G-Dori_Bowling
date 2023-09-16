using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private GameObject _ballSocket;
    private Rigidbody _rb;
    private GameObject _ball;
    void Start()
    {
        _ballSocket = GameObject.Find("BallSocket");
        _rb = GetComponent<Rigidbody>();
        _ball = GameObject.Find("Ball(Clone)");
    }

 

    public void BallStayAtPlayerHand(GameObject ball)
    {
        _ballSocket = GameObject.Find("BallSocket");
        ball.transform.position = _ballSocket.transform.position;
    }

    public void ThrowBall()
    {

        _rb.AddForce(new Vector3(-7500f, 500f, 0f));
        _rb.AddTorque(new Vector3(3000f, 0f, 0f));
        _rb.AddTorque(new Vector3(0f, 7000f, 0f));
    }

    public void DeleteBall(GameObject ball)
    {
        Destroy(ball);
    }
}
