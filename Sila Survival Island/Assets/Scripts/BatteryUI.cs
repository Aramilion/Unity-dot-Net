using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BatteryUI : MonoBehaviour
{
    public Sprite[] batteryStates;

    Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    public void ChangeBatteryState(int charge)
    {
        image.sprite = batteryStates[charge];
    }
}
