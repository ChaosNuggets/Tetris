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

    public static void setStartLevel(int level)
    {
        currentLevel = level;
        transitionLines = level <= 9 ? (level + 1) * 10 : (level >= 16 ? (level - 5) * 10 : 100);
        prevDivBy10 = transitionLines / 10;
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
                currentLevel++;
                ht.updateLevelText(currentLevel);
            }
        } else if (currentDivBy10 > prevDivBy10)
        {
            prevDivBy10 = currentDivBy10;
            currentLevel++;
            ht.updateLevelText(currentLevel);
        }
        Debug.Log(linesCleared);
    }
}
