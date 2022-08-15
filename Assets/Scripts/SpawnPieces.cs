using UnityEngine;

public class SpawnPieces : MonoBehaviour
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
    private static int nextPieceNum = -1;
    public GameObject nextBox;
    public GameObject board;
    private static Vector3 NEXTBOXPOS;
    private static Vector3 TOPOFBOARD;
    private static Vector3[] boardSpawnOffsets =
    {
        new Vector3(0.5f, -0.5f),
        new Vector3(0.5f, -0.5f),
        new Vector3(0.5f, -0.5f),
        new Vector3(-0.5f, -0.5f),
        new Vector3(0.5f, -0.5f),
        new Vector3(0.5f, -0.5f),
        new Vector3(0.5f, -0.5f)
    };
    private static Vector3[] nextBoxSpawnOffsets =
    {
        new Vector3(0, 0),
        new Vector3(0, 0),
        new Vector3(0, 0),
        new Vector3(-0.5f, 0),
        new Vector3(0, 0),
        new Vector3(0, 0),
        new Vector3(0.5f, -0.5f)
    };

    // Start is called before the first frame update
    void Start()
    {
        initializeVariables();
        spawnNextPiece();
        generateNewPiece();
    }

    private void initializeVariables()
    {
        NEXTBOXPOS = nextBox.transform.position;
        float boardHeight = board.transform.localScale.y;
        TOPOFBOARD = board.transform.position + new Vector3(0, boardHeight / 2);
    }

    private static void moveNextToBoard()
    {
        ActivePieces.currentPiece.createPiece(nextPieceNum, TOPOFBOARD + boardSpawnOffsets[nextPieceNum]);
    }

    private static void spawnNextPiece()
    {
        int pieceNum = Random.Range(0, 7);
        //Reroll if it's a repeat
        if (pieceNum == nextPieceNum)
        {
            pieceNum = Random.Range(0, 7);
        }
        //int pieceNum = 1;
        nextPieceNum = pieceNum;
        ActivePieces.nextPiece.createPiece(pieceNum, NEXTBOXPOS + nextBoxSpawnOffsets[pieceNum], true);
    }

    public static void generateNewPiece()
    {
        moveNextToBoard();
        spawnNextPiece();
    }
}
