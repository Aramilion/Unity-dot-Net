using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public float playerSpeed = 3.0f;
    public float ballforce = 300.0f;
    public GameObject ball;

    // Use this for initialization
    void Start ()
    {
        ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(ballforce, ballforce));
    }
	
	// Update is called once per frame
	void Update ()
    {
        float currentSpeed = Input.GetAxis("Horizontal") * Time.deltaTime * playerSpeed;
        transform.Translate(currentSpeed, 0, 0);
    }
}
