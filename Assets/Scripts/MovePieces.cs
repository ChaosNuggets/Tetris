using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePieces : MonoBehaviour
{
    //public GameObject nextBox;
    //public GameObject board;
    private bool hasHorizontalBeenReleased = true;
    private float timeSinceLastDrop = 0;
    private const float SOFTDROPTIME = 1f / 60f;
    private const float REGULARDROPTIME = 0.75f;
    private float timeBetweenDrops = REGULARDROPTIME;

    // Update is called once per frame
    void Update()
    {
        handleHorizontalMovement();
        handleVerticalMovement();
    }

    private void handleHorizontalMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        bool isRightPressed = horizontal > 0;
        bool isLeftPressed = horizontal < 0;
        if (hasHorizontalBeenReleased)
        {
            if (isRightPressed)
            {
                ActivePieces.currentTetromino.movePieceR(new Vector3(1, 0));
                hasHorizontalBeenReleased = false;
            }
            else if (isLeftPressed)
            {
                ActivePieces.currentTetromino.movePieceR(new Vector3(-1, 0));
                hasHorizontalBeenReleased = false;
            }
        }
        if (horizontal == 0)
        {
            hasHorizontalBeenReleased = true;
        }
    }

    private void handleVerticalMovement()
    {
        handleDownInput();
        makePieceFall();
    }

    private void handleDownInput()
    {
        float vertical = Input.GetAxis("Vertical");
        bool isDownPressed = vertical < 0;
        timeBetweenDrops = (isDownPressed ? SOFTDROPTIME : REGULARDROPTIME);
    }

    private void makePieceFall()
    {
        timeSinceLastDrop += Time.deltaTime;
        if (timeSinceLastDrop >= timeBetweenDrops)
        {
            ActivePieces.currentTetromino.movePieceR(new Vector3(0, -1));
            timeSinceLastDrop = 0;
        }
    }
}
