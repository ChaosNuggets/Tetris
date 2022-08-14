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
    public GameObject floor;
    public GameObject rightWall;
    public GameObject leftWall;

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
            bool isTouchingRight = ActivePieces.currentPiece.isTouching(rightWall);
            bool isTouchingLeft = ActivePieces.currentPiece.isTouching(leftWall);
            if (isRightPressed && !isTouchingRight)
            {
                ActivePieces.currentPiece.movePieceR(new Vector3(1, 0));
                hasHorizontalBeenReleased = false;
            } else if (isLeftPressed && !isTouchingLeft)
            {
                ActivePieces.currentPiece.movePieceR(new Vector3(-1, 0));
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
        if (shouldLockPiece())
        {
            ActivePieces.currentPiece.lockPiece();
            timeSinceLastDrop = 0;
            return;
        }
        handleDownInput();
        makePieceFall();
    }

    private bool shouldLockPiece()
    {
        bool isTouchingFloor = ActivePieces.currentPiece.isTouching(floor);
        Debug.Log($"isTouchingFloor: {isTouchingFloor}");
        Debug.Log($"timeSinceLastDrop: {timeSinceLastDrop}");
        if (isTouchingFloor && timeSinceLastDrop >= timeBetweenDrops)
        {
            timeSinceLastDrop = 0;
            return true;
        }
        return false;
    }

    private void handleDownInput()
    {
        float vertical = Input.GetAxis("Vertical");
        bool isDownPressed = vertical < 0;
        timeBetweenDrops = (isDownPressed ? SOFTDROPTIME : REGULARDROPTIME);
    }

    private void makePieceFall()
    {
        if (timeSinceLastDrop >= timeBetweenDrops)
        {
            ActivePieces.currentPiece.movePieceR(new Vector3(0, -1));
            timeSinceLastDrop = 0;
        }
        timeSinceLastDrop += Time.deltaTime;
    }
}
