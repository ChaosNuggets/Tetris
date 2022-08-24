using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePieces : MonoBehaviour
{
    public static Piece nextPiece;
    public static Piece currentPiece;
    //x and y of the placed boxes (x is + 4.5 and y is + 9.5)
    public static GameObject[,] placedBoxes = new GameObject[10, 23];
    void OnEnable()
    {
        nextPiece = ScriptableObject.CreateInstance<Piece>();
        currentPiece = ScriptableObject.CreateInstance<Piece>();
    }

    public static void addBoxesToArray(GameObject gameObject)
    {
        foreach (Transform box in gameObject.transform)
        {
            addBoxToPlacedBoxes(box);
        }
        gameObject.transform.DetachChildren();
        addBoxToPlacedBoxes(gameObject);
    }

    public static void addBoxToPlacedBoxes(GameObject gameObject)
    {
        addBoxToPlacedBoxes(gameObject.transform);
    }

    public static void addBoxToPlacedBoxes(Transform box)
    {
        int x = convertXtoIndex(box.position.x);
        int y = convertYtoIndex(box.position.y);
        placedBoxes[x, y] = box.gameObject;
    }

    public static int convertXtoIndex(float x)
    {
        return Mathf.RoundToInt(x + 4.5f);
    }

    public static int convertYtoIndex(float y)
    {
        return Mathf.RoundToInt(y + 9.5f);
    }
}
