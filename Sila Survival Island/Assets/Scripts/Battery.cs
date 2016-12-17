using UnityEngine;
using System.Collections;

public class Battery : MonoBehaviour
{
    public float speed = 10;

	void Update ()
    {
        transform.Rotate(new Vector3(0, 0, 1), speed);
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().CollectBattery();
            Destroy(gameObject);
        }
    }
}
