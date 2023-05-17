using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyImgSwitch : MonoBehaviour
{
    public Energy _energy;
    public RawImage batteryImage;
    public Texture[] batteryImages;

    private void Start()
    {
        UpdateBattery(_energy.energy);
    }

    private void Update()
    {
        Debug.Log(_energy.energy);
        UpdateBattery(_energy.energy);
    }

    public void UpdateBattery(int chargeLevel)
    {
        int level = Mathf.RoundToInt(chargeLevel / 20);

        switch (level)
        {
            case 0:
                batteryImage.texture = batteryImages[0];
                break;
            case 1:
                batteryImage.texture = batteryImages[1];
                break;
            case 2:
                batteryImage.texture = batteryImages[2];
                break;
            case 3:
                batteryImage.texture = batteryImages[3];
                break;
            case 4:
                batteryImage.texture = batteryImages[4];
                break;
            case 5:
                batteryImage.texture = batteryImages[5];
                break;
            default:
                break;
        }

        /*for(int i=0; i < batteryImages.Length; i++)
        {
            batteryImage.texture = batteryImages[i];
        }*/
    }
}
