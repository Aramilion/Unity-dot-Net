using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour
{
    public void StartFire()
    {
        GameObject fireOn = transform.FindChild("Campfire_On").gameObject;
        fireOn.SetActive(true);
    }
}
