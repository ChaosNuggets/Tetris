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
    private static int nextTetrominoNum = -1;
    public GameObject nextBox;
    public GameObject board;
    private static Vector3 NEXTBOXPOS;
    private static Vector3 TOPOFBOARD;
    private static Vector3[] boardSpawnOffsets =
    {
        new Vector3(0.5f, -0.5f),
        new Vector3(0.5f, -0.5f),
        new Vector3(0.5f, -0.5f),
        new Vector3(0, -1),
        new Vector3(0.5f, -0.5f),
        new Vector3(0.5f, -0.5f),
        new Vector3(0.5f, -0.5f)
    };
    private static Vector3[] nextBoxSpawnOffsets =
    {
        new Vector3(0, 0),
        new Vector3(0, 0),
        new Vector3(0, 0),
        new Vector3(0, -0.5f),
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

    // Update is called once per frame
    void Update()
    {
        
    }

    private void initializeVariables()
    {
        NEXTBOXPOS = nextBox.transform.position;
        float boardHeight = board.transform.localScale.y;
        TOPOFBOARD = board.transform.position + new Vector3(0, boardHeight / 2);
    }

    private void moveNextToBoard()
    {
        ActivePieces.currentTetromino.createPiece(nextTetrominoNum, TOPOFBOARD + boardSpawnOffsets[nextTetrominoNum]);
    }

    private void spawnNextPiece()
    {
        int tetrominoNum = Random.Range(0, 7);
        //Reroll if it's a repeat
        if (tetrominoNum == nextTetrominoNum)
        {
            tetrominoNum = Random.Range(0, 7);
        }
        nextTetrominoNum = tetrominoNum;
        ActivePieces.nextTetromino.createPiece(tetrominoNum, NEXTBOXPOS + nextBoxSpawnOffsets[tetrominoNum]);
    }

    private void generateNewPiece()
    {
        moveNextToBoard();
        spawnNextPiece();
    }
}
