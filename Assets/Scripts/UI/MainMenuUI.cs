using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuUI : MonoBehaviour
{
    public TMP_Text title;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChangeTitleColor();
    }

    private void ChangeTitleColor()
    {
        float hue = Mathf.PingPong(Time.time * 1f, 1);
        Color newColor = Color.HSVToRGB(hue, 0.5f, 0.8f);
        title.color = newColor;
    }
}
