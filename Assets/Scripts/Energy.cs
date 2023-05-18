using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    [Header("Buttons")]
    public ButtonController leftBtnController;
    public ButtonController rightBtnController;
    public ButtonController middleBtnController;

    [Header("")]
    public CameraController tablet;

    public int energy = 100;
    public bool canInteract = true;

    private float energyLossRate = 5f;
    private float energyLossTimer = 0f;

    void Update()
    {
        if (energy < 95f)
        {
            leftBtnController.door.GetComponent<Animator>().SetBool("isOpened", false);
            rightBtnController.door.GetComponent<Animator>().SetBool("isOpened", false);
            middleBtnController.door.GetComponent<Animator>().SetBool("isOpened", false);

            canInteract = false;
            tablet.OffTabletAndCameras();
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
