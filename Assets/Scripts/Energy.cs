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
            energyLossTimer += Time.deltaTime; // ����������� ������ �� ��������� �����
            if (energyLossTimer >= energyLossRate) // ���� ������ ���������� �������
            {
                energy -= 1; // ��������� ������� �� 1 �������
                Debug.Log(energyLossRate);
                Debug.Log(energyLossTimer);
                energyLossTimer = 0f; // ���������� ������
            }
        }

        //Debug.Log(energy);
    }
}
