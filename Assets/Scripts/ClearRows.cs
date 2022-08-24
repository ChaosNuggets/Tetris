using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearRows
{
    public static void clearFullRows()
    {
        int topOfBoard = 23;
        for (int row = 0; row < topOfBoard; row++)
        {
            bool shouldClear = true;
            for (int column = 0; column < 10; column++)
            {
                if (ActivePieces.placedBoxes[column, row] == null)
                {
                    shouldClear = false;
                    break;
                }
            }
            if (shouldClear)
            {
                //Debug.Log($"Clearing row {row}");
                clearRow(row, topOfBoard);
                row--;
                topOfBoard--;
            }
        }
    }

    private static void clearRow(int row, int topOfBoard)
    {
        destroyRow(row);
        moveBoxesDown(row, topOfBoard);
    }

    private static void destroyRow(int row)
    {
        for (int column = 0; column < 10; column++)
        {
            Object.Destroy(ActivePieces.placedBoxes[column, row]);
            ActivePieces.placedBoxes[column, row] = null;
        }
    }

    private static void moveBoxesDown(int row, int topOfBoard)
    {
        for (; row < topOfBoard - 1; row++)
        {
            for (int column = 0; column < 10; column++)
            {
                if (ActivePieces.placedBoxes[column, row + 1] != null)
                {
                    ActivePieces.placedBoxes[column, row + 1].transform.position -= new Vector3(0, 1);
                    ActivePieces.placedBoxes[column, row] = ActivePieces.placedBoxes[column, row + 1];
                    ActivePieces.placedBoxes[column, row + 1] = null;
                }
            }
        }
    }
}
