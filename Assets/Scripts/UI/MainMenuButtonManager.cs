using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonManager : MonoBehaviour
{
    public GameObject gameMode;

    public void GameModeOn()
    {
        gameMode.SetActive(true);
    }

    public void GameModeOff()
    {
        gameMode.SetActive(false);
    }

    public void StandardMode()
    {
        SceneManager.LoadScene("StandardMode");
    }
}
