using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleLevels : MonoBehaviour
{
    private static int linesCleared = 0;
    private static int currentLevel;
    private static bool isOnFirstLevel = true;
    private static int transitionLines;
    private static int prevDivBy10;
    public GameObject canvas;
    private static HandleText ht;


    private void OnEnable()
    {
        ht = canvas.GetComponent<HandleText>();
    }

    private static float calculateDropTime(int level)
    {
        float[] droptimes =
        {
            48f / 60f,
            43f / 60f,
            38f / 60f,
            33f / 60f,
            28f / 60f,
            23f / 60f,
            18f / 60f,
            13f / 60f,
            8f / 60f,
            6f / 60f,
            5f / 60f,
            5f / 60f,
            5f / 60f,
            4f / 60f,
            4f / 60f,
            4f / 60f,
            3f / 60f,
            3f / 60f,
            3f / 60f
        };
        return level < 19 ? droptimes[level] :
            level < 29 ? 2f / 60f : 1f / 60f;
    }

    public static void setStartLevel(int level)
    {
        currentLevel = level;
        transitionLines = level <= 9 ? (level + 1) * 10 :
            level >= 16 ? (level - 5) * 10 : 100;
        MovePieces.regularDropTime = calculateDropTime(currentLevel);
    }

    private static void incrementLevel(int currentDivBy10)
    {
        prevDivBy10 = currentDivBy10;
        currentLevel++;
        ht.updateLevelText(currentLevel);
        MovePieces.regularDropTime = calculateDropTime(currentLevel);
    }
    
    public static void addLineClear()
    {
        linesCleared++;
        int currentDivBy10 = linesCleared / 10;
        if (isOnFirstLevel)
        {
            if (linesCleared >= transitionLines)
            {
                isOnFirstLevel = false;
                incrementLevel(currentDivBy10);
            }
        } else if (currentDivBy10 > prevDivBy10)
        {
            incrementLevel(currentDivBy10);
        }
        Debug.Log(linesCleared);
    }
}
