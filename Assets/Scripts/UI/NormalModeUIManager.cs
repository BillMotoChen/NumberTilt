using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NormalModeUIManager : MonoBehaviour
{
    public TMP_Text nextNumberText;
    public TMP_Text timerText;

    private float gameTime;

    // Start is called before the first frame update
    void Start()
    {
        gameTime = 0f;
        UpdateTimer(gameTime);
    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;
        UpdateTimer(gameTime);
    }

    public void updateNextNumberText (int nextNumber)
    {
        //nextNumberText.text = "Next\n" + nextNumber.ToString();
        nextNumberText.text = nextNumber.ToString();
    }

    private void UpdateTimer(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time % 60F);
        float milliseconds = (time * 100F) % 100F;

        timerText.text = string.Format("{0}:{1:00}.{2:00}", minutes, seconds, milliseconds);
    }
}
