using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Piece", order = 1)]
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
    public static GameObject[] tetrominoes = new GameObject[7];
    private GameObject tetromino = null;
    public int tetrominoNum;

    //public something[4] rotationInstructions;

    private void OnEnable()
    {
        tetrominoes[0] = Resources.Load<GameObject>("T");
        tetrominoes[1] = Resources.Load<GameObject>("J");
        tetrominoes[2] = Resources.Load<GameObject>("Z");
        tetrominoes[3] = Resources.Load<GameObject>("Square");
        tetrominoes[4] = Resources.Load<GameObject>("S");
        tetrominoes[5] = Resources.Load<GameObject>("L");
        tetrominoes[6] = Resources.Load<GameObject>("Line");
    }

    public void createPiece(int tetrominoNum, Vector3 spawnPos)
    {
        this.tetrominoNum = tetrominoNum;
        if (tetromino != null)
        {
            Destroy(tetromino);
        }
        tetromino = Instantiate(tetrominoes[tetrominoNum], spawnPos, Quaternion.identity);
    }

    //public void movePiece(Vector3 movePos)
    //{
    //    tetromino.transform.position = movePos;
    //}

    public void movePieceR(Vector3 movePos)
    {
        tetromino.transform.position += movePos;
    }
}