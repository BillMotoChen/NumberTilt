using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject gameover;


    public GameObject gameClear;
    public TMP_Text gameClearTimeText;

    // Start is called before the first frame update
    void Start()
    {
        gameover.SetActive(false);
        gameClear.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        gameover.SetActive(true);
    }

    public void GameClear(string timeText)
    {
        Time.timeScale = 0f;
        gameClear.SetActive(true);
        gameClearTimeText.text = timeText;
    }
}
