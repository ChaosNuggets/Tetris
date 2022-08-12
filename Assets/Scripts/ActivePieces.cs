using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePieces : MonoBehaviour
{
    public static Piece nextTetromino;
    public static Piece currentTetromino;

    void OnEnable()
    {
        nextTetromino = ScriptableObject.CreateInstance<Piece>();
        currentTetromino = ScriptableObject.CreateInstance<Piece>();
    }
}
