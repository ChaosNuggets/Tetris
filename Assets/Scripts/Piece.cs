using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Piece", order = 1)]
public class Piece : ScriptableObject
{
    /* 
     * 0 T
     * 1 J
     * 2 Z
     * 3 Square
     * 4 S
     * 5 L
     * 6 Line
     */
    public static GameObject[] pieces = new GameObject[7];
    private GameObject piece = null;
    public int pieceNum;

    private void OnEnable()
    {
        pieces[0] = Resources.Load<GameObject>("T");
        pieces[1] = Resources.Load<GameObject>("J");
        pieces[2] = Resources.Load<GameObject>("Z");
        pieces[3] = Resources.Load<GameObject>("Square");
        pieces[4] = Resources.Load<GameObject>("S");
        pieces[5] = Resources.Load<GameObject>("L");
        pieces[6] = Resources.Load<GameObject>("Line");
    }

    public void createPiece(int pieceNum, Vector3 spawnPos, bool destroyPiece = false)
    {
        this.pieceNum = pieceNum;
        if (destroyPiece)
        {
            Destroy(piece);
        }
        piece = Instantiate(pieces[pieceNum], spawnPos, Quaternion.identity);
    }

    //public void movePiece(Vector3 movePos)
    //{
    //    tetromino.transform.position = movePos;
    //}

    public void movePieceR(Vector3 movePos)
    {
        piece.transform.position += movePos;
    }

    public void rotatePieceCCW()
    {
        piece.transform.Rotate(new Vector3(0, 0, 90));
    }

    public void rotatePieceCW()
    {
        piece.transform.Rotate(new Vector3(0, 0, -90));
    }

    public bool isTouchingRightWall()
    {
        foreach (Transform transform in piece.transform)
        {
            if (transform.position.x >= 4)
            {
                return true;
            }
        }
        return false;
    }

    public bool isTouchingLeftWall()
    {
        foreach (Transform transform in piece.transform)
        {
            if (transform.position.x <= -4)
            {
                return true;
            }
        }
        return false;
    }

    public bool isTouchingFloor()
    {
        foreach (Transform transform in piece.transform)
        {
            if (transform.position.y <= -9)
            {
                return true;
            }
        }
        return false;
    }

    public bool isTouchingPieceTop()
    {
        foreach (Transform transform in piece.transform)
        {
            float x = transform.position.x;
            float y = transform.position.y;
            int xIndex = ActivePieces.convertXtoIndex(x);
            int yIndex = ActivePieces.convertYtoIndex(y) - 1;
            if (isOutOfBounds(xIndex, yIndex))
            {
                return false;
            }
            if (ActivePieces.placedBoxes[xIndex, yIndex] != null)
            {
                return true;
            }
        }
        return false;
    }

    public bool isTouchingPieceRight()
    {
        foreach (Transform transform in piece.transform)
        {
            float x = transform.position.x;
            float y = transform.position.y;
            int xIndex = ActivePieces.convertXtoIndex(x) + 1;
            int yIndex = ActivePieces.convertYtoIndex(y);
            if (isOutOfBounds(xIndex, yIndex))
            {
                return false;
            }
            if (ActivePieces.placedBoxes[xIndex, yIndex] != null)
            {
                return true;
            }
        }
        return false;
    }
    public bool isTouchingPieceLeft()
    {
        foreach (Transform transform in piece.transform)
        {
            float x = transform.position.x;
            float y = transform.position.y;
            int xIndex = ActivePieces.convertXtoIndex(x) - 1;
            int yIndex = ActivePieces.convertYtoIndex(y);
            if (isOutOfBounds(xIndex, yIndex))
            {
                return false;
            }
            if (ActivePieces.placedBoxes[xIndex, yIndex] != null)
            {
                return true;
            }
        }
        return false;
    }

    private static bool isOutOfBounds(int xIndex, int yIndex)
    {
        return (xIndex < 0 || xIndex > 9 || yIndex < 0 || yIndex > 19) ? true : false;
    }

    public void lockPiece()
    {
        addBoxesToArray();
        MovePieces.justLocked = true;
        SpawnPieces.generateNewPiece();
    }

    private void addBoxesToArray()
    {
        foreach (Transform box in piece.transform)
        {
            ActivePieces.addBoxToPlacedBoxes(box);
        }
        piece.transform.DetachChildren();
        ActivePieces.addBoxToPlacedBoxes(piece);
    }
}