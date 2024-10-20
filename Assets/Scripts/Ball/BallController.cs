using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallController : MonoBehaviour
{
    public const int STAGE_CLEAR_GOAL = 50;

    public float speed = 10f;
    private Rigidbody2D rb;
    private int targetNunmber;
    private PlateManager plateManager;

    private NormalModeUIManager normalModeUIManager;
    private GameManager gameManager;

    private bool enterPlate;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        plateManager = GameObject.Find("Managers/PlateManager").GetComponent<PlateManager>();
        normalModeUIManager = GameObject.Find("Managers/NormalModeUIManager").GetComponent<NormalModeUIManager>();
        gameManager = GameObject.Find("Managers/GameManager").GetComponent<GameManager>();

        targetNunmber = 1;
        normalModeUIManager.updateNextNumberText(targetNunmber);

        enterPlate = false;
    }

    //Update is called once per frame
    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(moveX, moveY) * speed;
    }

    //void FixedUpdate()
    //{
    //    float threshold = 0.05f;

    //    float moveX = Input.acceleration.x;
    //    float moveY = Input.acceleration.y;

    //    if (Mathf.Abs(moveX) < threshold) moveX = 0;
    //    if (Mathf.Abs(moveY) < threshold) moveY = 0;

    //    rb.velocity = new Vector2(moveX, moveY) * speed;
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Plate")
        {
            TMP_Text text = collision.gameObject.GetComponentInChildren<TMP_Text>();

            if (text.text != null)
            {
                int collisionNumber;
                collisionNumber = int.Parse(text.text);
                if (collisionNumber == targetNunmber && enterPlate == false)
                {
                    if (collisionNumber == STAGE_CLEAR_GOAL)
                    {
                        gameManager.GameClear(normalModeUIManager.timerText.text);
                    }
                    targetNunmber++;
                    plateManager.HitCorrectTarget();
                    normalModeUIManager.updateNextNumberText(targetNunmber);
                    text.text = null;
                }
                else if (collisionNumber != targetNunmber && enterPlate == false)
                {
                    plateManager.HitWrongTarget();
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Plate")
        {
            enterPlate = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Plate")
        {
            enterPlate = false;
        }
    }
}