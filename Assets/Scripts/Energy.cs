using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    public int energy = 100;
    public LeftButtonController btnController;
    public float energyLossRate = 3f;

    private float energyLossTimer = 0f;

    void Update()
    {
        if (btnController.doorIsOpen)
        {
            energyLossTimer += Time.deltaTime; // увеличиваем таймер на прошедшее время
            if (energyLossTimer >= energyLossRate) // если прошло достаточно времени
            {
                energy -= 1; // уменьшаем энергию на 1 единицу
                Debug.Log(energyLossRate);
                Debug.Log(energyLossTimer);
                energyLossTimer = 0f; // сбрасываем таймер
            }
        }

        //Debug.Log(energy);
    }
}
