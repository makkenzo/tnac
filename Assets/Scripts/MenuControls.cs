using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControls : MonoBehaviour
{
    public Button continueButton;
    public Button[] nightButtons;

    private int curNight = 1;
    private int maxNights = 3;
    private bool hasSave = false;
    private string savePath = "save.json";

    private void Start()
    {
        if (!File.Exists(savePath))
        {
            CreateNewSaveFile();
        }
        LoadSaveData();
        UpdateNightButtons();
        UpdateContinueButton();
    }

    public void NewGame()
    {
        curNight = 1;
        hasSave = true;
        SaveGameData();
        StartNight();
    }

    public void Continue()
    {
        if (hasSave)
        {
            LoadSaveData();
            StartNight();
        }
    }

    public void SelectNight(int night)
    {
        curNight = night;
        StartNight();
    }

    private void UpdateContinueButton()
    {
        continueButton.interactable = hasSave;
    }

    private void UpdateNightButtons()
    {
        for (int i = 0; i < nightButtons.Length; i++)
        {
            if (i < curNight)
            {
                nightButtons[i].interactable = true;
            }
            else
            {
                nightButtons[i].interactable = false;
            }
        }
    }

    private void CreateNewSaveFile()
    {
        SaveData saveData = new SaveData()
        {
            currentNight = 1,
            hasSave = false
        };

        string jsonData = JsonUtility.ToJson(saveData);
        File.WriteAllText(savePath, jsonData);
    }

    private void LoadSaveData()
    {
        string jsonData = File.ReadAllText(savePath);
        SaveData saveData = JsonUtility.FromJson<SaveData>(jsonData);

        if (saveData != null)
        {
            curNight = saveData.currentNight;
            hasSave = saveData.hasSave;
        }
    }

    private void StartNight()
    {
        SceneManager.LoadScene("Main");
    }

    private void SaveGameData()
    {
        SaveData saveData = new SaveData()
        {
            currentNight = curNight,
            hasSave = hasSave
        };

        string jsonData = JsonUtility.ToJson(saveData);
        File.WriteAllText(savePath, jsonData);
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exit");
    }

    [System.Serializable]
    private class SaveData
    {
        public int currentNight;
        public bool hasSave;
    }
}