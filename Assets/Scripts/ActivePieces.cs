using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePieces : MonoBehaviour
{
    public static Piece nextPiece;
    public static Piece currentPiece;
    public static List<GameObject> placedBoxes = new();

    void OnEnable()
    {
        nextPiece = ScriptableObject.CreateInstance<Piece>();
        currentPiece = ScriptableObject.CreateInstance<Piece>();
    }
}
