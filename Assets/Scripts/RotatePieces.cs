using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePieces : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("z"))
        {
            ActivePieces.currentPiece.rotatePieceCCW();
        }
        if (Input.GetKeyDown("x"))
        {
            ActivePieces.currentPiece.rotatePieceCW();
        }
    }
}
