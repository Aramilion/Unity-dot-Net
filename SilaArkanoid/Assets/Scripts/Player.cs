using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public static Player instance;

    public float playerSpeed = 3.0f;
    public float ballforce = 300.0f;
    public GameObject ball;

    public GameObject ballPrefab;

    private bool isHoldingBall = true;

    void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
        //Desktop Input
        float currentSpeed = Input.GetAxis("Horizontal") * Time.deltaTime * playerSpeed;
        transform.Translate(currentSpeed, 0, 0);

        if(Input.GetButtonDown("Jump") && isHoldingBall)
        {
            ball.transform.SetParent(null);
            AddForceToBall();
            isHoldingBall = false;
        }

        //Touch Screen Input
        if (Input.touches.Length < 1)
            return;

        Touch currentTouch = Input.touches[0];
        Vector2 touchPosition = Camera.main.ScreenToWorldPoint(currentTouch.position);

        //Add fore toBall
        if (touchPosition.y > 0)
        {
            ball.transform.SetParent(null);
            AddForceToBall();
            isHoldingBall = false;
            return;
        }

        //move player
        float offset = Time.deltaTime * playerSpeed;
        float moveThorwardsOffset = Mathf.MoveTowards(transform.position.x, touchPosition.x, offset);

        if (transform.position.x > touchPosition.x)
        {
            //move left  
            
            transform.position = new Vector3(moveThorwardsOffset, transform.position.y, transform.position.z);
        }
        else
        {
            //move right 
            transform.position = new Vector3(moveThorwardsOffset, transform.position.y, transform.position.z);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.transform.SetParent(transform);
            isHoldingBall = true;
        }
    }
    
    public void AddForceToBall()
    {
        ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(ballforce, ballforce));
    }

    public void CreateNewBall()
    {
        Invoke("CreateNewBallDelayer", 1);
    }

    private void CreateNewBallDelayer()
    {
        GameObject newBall = Instantiate(ballPrefab, new Vector3(0, -10, 0), Quaternion.identity) as GameObject;
        ball = newBall;
        ball.transform.SetParent(transform);
        ball.transform.localPosition = new Vector3(0, 0.75f, 0);
        isHoldingBall = true;
    }
}
