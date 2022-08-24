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
    public int rotStatus = 0;

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
        rotStatus = 0;
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

    public void rotatePiece(float rotation)
    {
        piece.transform.Rotate(new Vector3(0, 0, rotation));
        if (rotStatus == 3)
        {
            rotStatus = 0;
        } else
        {
            rotStatus++;
        }
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
        return piece.transform.position.x >= 4;
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
        return piece.transform.position.x <= -4;
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
        return piece.transform.position.y <= -9;
    }

    public bool isTouchingPieceTop()
    {
        foreach (Transform transform in piece.transform)
        {
            if (testForBox(transform, 0, -1))
            {
                return true;
            }
        }
        return testForBox(piece.transform, 0, -1);
    }

    public bool isTouchingPieceRight()
    {
        foreach (Transform transform in piece.transform)
        {
            if (testForBox(transform, 1, 0))
            {
                return true;
            }
        }
        return testForBox(piece.transform, 1, 0);
    }
    public bool isTouchingPieceLeft()
    {
        foreach (Transform transform in piece.transform)
        {
            if (testForBox(transform, -1, 0))
            {
                return true;
            }
        }
        return testForBox(piece.transform, -1, 0);
    }

    private static bool testForBox(Transform transform, int xOffset, int yOffset)
    {
        float x = transform.position.x;
        float y = transform.position.y;
        int xIndex = ActivePieces.convertXtoIndex(x) + xOffset;
        int yIndex = ActivePieces.convertYtoIndex(y) + yOffset;
        if (isOutOfBounds(xIndex, yIndex))
        {
            return false;
        }
        return ActivePieces.placedBoxes[xIndex, yIndex] != null;
    }

    private static bool isOutOfBounds(int xIndex, int yIndex)
    {
        return (xIndex < 0 || xIndex > 9 || yIndex < 0 || yIndex > 22) ? true : false;
    }

    public void lockPiece()
    {
        ActivePieces.addBoxesToArray(piece);
        //string lol = "";
        //for (int y = 19; y >= 0; y--)
        //{
        //    for (int x = 0; x < 10; x++)
        //    {
        //        if (ActivePieces.placedBoxes[x, y] == null)
        //        {
        //            lol += "n ";
        //        } else
        //        {
        //            lol += "y ";
        //        }
        //    }
        //    lol += '\n';
        //}
        //Debug.Log(lol);
        MovePieces.justLocked = true;
        ClearRows.clearFullRows();
        SpawnPieces.generateNewPiece();
    }
}