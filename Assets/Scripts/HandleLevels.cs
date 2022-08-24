using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleLevels
{
    private static int linesCleared = 0;
    private static int currentLevel;
    private static bool isOnFirstLevel = true;
    private static int transitionLines;
    private static int prevDivBy10;

    public static void setStartLevel(int level)
    {
        currentLevel = level;
        transitionLines = level <= 9 ? (level + 1) * 10 : level >= 16 ? (level - 5) * 10 : 100;
        prevDivBy10 = transitionLines / 10;
    }
    
    public static void addLineClear()
    {
        linesCleared++;
        if (isOnFirstLevel)
        {
            if (linesCleared >= transitionLines)
            {
                isOnFirstLevel = false;
                currentLevel++;
            }
        } else if (linesCleared / 10 > prevDivBy10)
        {
            currentLevel++;
        }
        Debug.Log(currentLevel);
    }
}
