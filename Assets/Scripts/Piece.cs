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
    private Vector3[] poses = new Vector3[4];

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
        updatePoses();
    }

    //public void movePiece(Vector3 movePos)
    //{
    //    tetromino.transform.position = movePos;
    //}

    public void movePieceR(Vector3 movePos)
    {
        piece.transform.position += movePos;
        updatePoses();
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
        foreach (Vector3 unlockedPos in poses)
        {
            float x = unlockedPos.x;
            float y = unlockedPos.y;
            int xIndex = ActivePieces.convertXtoIndex(x);
            int yIndex = ActivePieces.convertYtoIndex(y);

        }
        return false;
    }

    public bool isTouchingPieceRight()
    {
        foreach (Vector3 unlockedPos in poses)
        {
            float unlockedPosX = unlockedPos.x;
            float unlockedPosY = unlockedPos.y;
            foreach (GameObject box in ActivePieces.placedBoxes)
            {
                float lockedPosY = box.transform.position.y;
                if (unlockedPosY != lockedPosY)
                {
                    continue;
                }
                float lockedPosX = box.transform.position.x;
                if (unlockedPosX - lockedPosX != -1)
                {
                    continue;
                }
                return true;
            }
        }
        return false;
    }
    public bool isTouchingPieceLeft()
    {
        foreach (Vector3 unlockedPos in poses)
        {
            float unlockedPosX = unlockedPos.x;
            float unlockedPosY = unlockedPos.y;
            foreach (GameObject box in ActivePieces.placedBoxes)
            {
                float lockedPosY = box.transform.position.y;
                if (unlockedPosY != lockedPosY)
                {
                    continue;
                }
                float lockedPosX = box.transform.position.x;
                if (unlockedPosX - lockedPosX != 1)
                {
                    continue;
                }
                return true;
            }
        }
        return false;
    }

    private void updatePoses()
    {
        int index = 0;
        foreach (Transform unlockedTransform in piece.transform)
        {
            poses[index] = unlockedTransform.position;
            index++;
        }
        poses[3] = piece.transform.position;
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

    public Vector3 getPosition()
    {
        return piece.transform.position;
    }
}