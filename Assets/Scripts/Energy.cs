using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    [Header("Buttons")]
    public ButtonController leftBtnController;
    public ButtonController rightBtnController;
    public ButtonController middleBtnController;

    [Header("Light")]
    public Light[] lights;
    public Light mainLight;
    public float flickerInterval = 0.3f;
    public float turnOffDelay = 3f;

    [Header("")]
    public CameraController tablet;

    public int energy = 100;
    public bool canInteract = true;

    private float energyLossRate = 5f;
    private float energyLossTimer = 0f;

    private bool isLightOn = true;
    private float flickerTimer = 0f;
    private float turnOffTimer = 0f;

    void Update()
    {
        if (energy < 1f && !canInteract)
        {
            Debug.Log("мерцыание");
            flickerTimer += Time.deltaTime;
            turnOffTimer += Time.deltaTime;

            if (flickerTimer >= flickerInterval)
            {
                if (isLightOn)
                {
                    mainLight.enabled = false;
                }
                else
                {
                    mainLight.enabled = true;
                }

                isLightOn = !isLightOn;
                flickerTimer = 0f;
            }

            if (turnOffTimer >= turnOffDelay)
            {
                mainLight.enabled = false;
            }
        }

        if (energy < 1f && canInteract)
        {
            leftBtnController.door.GetComponent<Animator>().SetBool("isOpened", false);
            rightBtnController.door.GetComponent<Animator>().SetBool("isOpened", false);
            middleBtnController.door.GetComponent<Animator>().SetBool("isOpened", false);

            canInteract = false;
            tablet.OffTabletAndCameras();

            foreach (Light light in lights)
            {
                light.enabled = false;
            }
        }

        if (leftBtnController.doorIsOpen)
        {
            energyLossTimer += Time.deltaTime;
            if (energyLossTimer >= energyLossRate)
            {
                energy -= 1;
                energyLossTimer = 0f;
            }
        }

        if (rightBtnController.doorIsOpen)
        {
            energyLossTimer += Time.deltaTime;
            if (energyLossTimer >= energyLossRate)
            {
                energy -= 1;
                energyLossTimer = 0f;
            }
        }

        if (middleBtnController.doorIsOpen)
        {
            energyLossTimer += Time.deltaTime;
            if (energyLossTimer >= energyLossRate)
            {
                energy -= 1;
                energyLossTimer = 0f;
            }
        }

        if (tablet.isTabletOpen)
        {
            energyLossTimer += Time.deltaTime;
            if (energyLossTimer >= energyLossRate)
            {
                energy -= 1;
                energyLossTimer = 0f;
            }
        }
    }
}
