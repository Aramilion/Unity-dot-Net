using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    int points = 0;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("I collided");
        if (collision.gameObject.tag == "Brick")
        {
            points++;
            Destroy(collision.gameObject);
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(Vector2.zero, new Vector2(200, 20)), points.ToString());
    }
}
