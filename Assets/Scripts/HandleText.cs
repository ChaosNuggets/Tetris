using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HandleText : MonoBehaviour
{
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI levelNum;
    public GameObject levelBox;
    public TextMeshProUGUI nextText;
    public GameObject nextBox;

    private void moveToPos(ref TextMeshProUGUI text, GameObject obj, Vector3 worldOffset)
    {
        Vector3 worldPos = obj.transform.position + worldOffset;
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);
        text.transform.position = screenPos;
    }

    private void moveToPos(ref TextMeshProUGUI text, GameObject obj)
    {
        moveToPos(ref text, obj, new Vector3());
    }

    private void repositionText()
    {
        moveToPos(ref levelText, levelBox, new Vector3(0, 0.75f));
        moveToPos(ref levelNum, levelBox, new Vector3(0, -0.75f));
        moveToPos(ref nextText, nextBox, new Vector3(0, 1.75f));
    }

    private void OnEnable()
    {
        repositionText();
    }

    public void updateLevelText(int level)
    {
        levelNum.text = level.ToString("D2");
    }
}
