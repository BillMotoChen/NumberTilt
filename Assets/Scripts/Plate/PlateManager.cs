using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlateManager : MonoBehaviour
{
    public GameObject[] plates;
    public TMP_Text[] platesText;

    public int nextNumber;

    private LiveManager liveManager;
    
    void Start()
    {
        liveManager = GameObject.Find("Managers/LivesManager").GetComponent<LiveManager>();

        foreach (TMP_Text text in platesText)
        {
            text.text = null;
        }

        nextNumber = 1;
        for (int i = 0; i < 4; i++)
        {
            GenerateNextNumber(nextNumber++);
        }
    }

    public void GenerateNextNumber(int num)
    {
        List<int> emptyPlateIndices = new List<int>();

        for (int i = 0; i < platesText.Length; i++)
        {
            if (string.IsNullOrEmpty(platesText[i].text))
            {
                emptyPlateIndices.Add(i);
            }
        }

        if (emptyPlateIndices.Count == 0)
        {
            Debug.Log("No empty plates available.");
            return;
        }

        int randomIndex = emptyPlateIndices[Random.Range(0, emptyPlateIndices.Count)];
        platesText[randomIndex].text = num.ToString();
    }

    public void HitCorrectTarget()
    {
        if (nextNumber <= BallController.STAGE_CLEAR_GOAL)
        {
            GenerateNextNumber(nextNumber++);
        }
    }

    public void HitWrongTarget()
    {
        liveManager.updateLives(-1);
    }
}
