using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Ball")
        {
            Destroy(collider.gameObject);

            Player.instance.CreateNewBall();
        }
    }
}
