using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RepositionText : MonoBehaviour
{
    public TextMeshProUGUI levelText;
    public GameObject levelBox;
    public TextMeshProUGUI nextText;
    public GameObject nextBox;

    private void moveToPos(ref TextMeshProUGUI text, ref GameObject obj, Vector3 worldOffset)
    {
        Vector3 worldPos = obj.transform.position + worldOffset;
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);
        text.transform.position = screenPos;
    }

    private void moveToPos(ref TextMeshProUGUI text, ref GameObject obj)
    {
        moveToPos(ref text, ref obj, new Vector3());
    }

    // Start is called before the first frame update
    void Start()
    {
        moveToPos(ref levelText, ref levelBox);
        moveToPos(ref nextText, ref nextBox, new Vector3(0, 2));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
