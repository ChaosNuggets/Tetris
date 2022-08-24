using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePieces : MonoBehaviour
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

    public enum Rotation
    {
        CW = -90,
        CCW = 90,
        NONE = 0
    }

    //These are the rotation instructions when you press x
    private Rotation[,] rotInstructions =
    {
        {Rotation.CW, Rotation.CW, Rotation.CW, Rotation.CW},
        {Rotation.CW, Rotation.CW, Rotation.CW, Rotation.CW},
        {Rotation.CCW, Rotation.CW, Rotation.CCW, Rotation.CW},
        {Rotation.NONE, Rotation.NONE, Rotation.NONE, Rotation.NONE},
        {Rotation.CCW, Rotation.CW, Rotation.CCW, Rotation.CW},
        {Rotation.CW, Rotation.CW, Rotation.CW, Rotation.CW},
        {Rotation.CW, Rotation.CCW, Rotation.CW, Rotation.CCW}
    };

    // Update is called once per frame
    void Update()
    {
        handleZKey();
        handleXKey();
    }

    private void handleZKey()
    {
        if (Input.GetKeyDown("z"))
        {
            int rotStatus = ActivePieces.currentPiece.rotStatus;
            int pieceNum = ActivePieces.currentPiece.pieceNum;
            float instruction = ((float)rotInstructions[pieceNum, rotStatus]) * -1;
            ActivePieces.currentPiece.tryToRotatePiece(instruction);
        }
    }

    private void handleXKey()
    {
        if (Input.GetKeyDown("x"))
        {
            int rotStatus = ActivePieces.currentPiece.rotStatus;
            int pieceNum = ActivePieces.currentPiece.pieceNum;
            float instruction = (float)rotInstructions[pieceNum, rotStatus];
            ActivePieces.currentPiece.tryToRotatePiece(instruction);
        }
    }
}
