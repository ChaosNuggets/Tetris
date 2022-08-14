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
    private Rigidbody2D rb;
    private CompositeCollider2D collider;
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
        rb = piece.GetComponent<Rigidbody2D>();
        collider = piece.GetComponent<CompositeCollider2D>();
    }

    //public void movePiece(Vector3 movePos)
    //{
    //    tetromino.transform.position = movePos;
    //}

    public void movePieceR(Vector3 movePos)
    {
        rb.MovePosition(piece.transform.position + movePos);
    }

    public bool isTouching(GameObject gameObject)
    {
        Collider2D cl = gameObject.GetComponent<Collider2D>();
        return collider.IsTouching(cl);
    }

    public void lockPiece()
    {
        foreach (Transform box in piece.transform)
        {
            ActivePieces.placedBoxes.Add(box.gameObject);
        }
        piece.transform.DetachChildren();
        SpawnPieces.generateNewPiece();
    }
}