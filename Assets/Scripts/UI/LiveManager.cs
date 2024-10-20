using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiveManager : MonoBehaviour
{
    private const int LIVES_MAX = 3;
    private int lives;

    public Sprite redHearts;
    public Sprite blackHearts;

    private GameManager gameManager;

    public Image[] hearts;

    // Start is called before the first frame update
    void Start()
    {
        lives = LIVES_MAX;
        updateImages();
        gameManager = GameObject.Find("Managers/GameManager").GetComponent<GameManager>();
    }

    public void updateLives(int i)
    {
        if (i > 0)
        {
            lives = Mathf.Max(lives + i, LIVES_MAX);
            updateImages();
        }
        else if (i < 0)
        {
            lives = Mathf.Max(lives + i, 0);
            updateImages();

            if (lives <= 0)
            {
                gameManager.GameOver();
            }
        }
    }

    private void updateImages()
    {
        foreach (Image heart in hearts)
        {
            heart.sprite = blackHearts;
        }

        for (int i=0; i<lives; i++)
        {
            hearts[i].sprite = redHearts;
        }
    }
    
}
