using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    int batteryCout = 0;
    public LayerMask layerMask;
    public BatteryUI batteryUI;
    public AudioSource batteryCollectSound;

    bool hasMatches = false;

	void Update ()
    {
        Transform cameraTransform = Camera.main.transform;
        //Debug.DrawRay(cameraTransform.position, cameraTransform.forward * 3, Color.green);

	    if(Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if(Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, 3, layerMask))
            {
                //Debug.Log(hit.transform.name);
                if(hit.transform.name == "Matches")
                {
                    hasMatches = true;
                }

                Fire fire = hit.transform.gameObject.GetComponent<Fire>();
                if(fire != null)
                {
                    if(hasMatches)
                    {
                        fire.StartFire();
                    }
                    else
                    {
                        Debug.Log("You don't have matches");
                    }
                }
            }
        }
	}

    public void CollectBattery()
    {
        batteryCout++;
        batteryUI.ChangeBatteryState(batteryCout);
        batteryCollectSound.Play();
    }
}
