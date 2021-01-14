using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info : MonoBehaviour
{
    [TextArea]
    public string description = "<b>TITLE</b>";
    Outline outline;

    void Awake()
    {
        outline = GetComponent<Outline>();
        outline.enabled = false;
        outline.OutlineWidth = 3;
    }


    public void Display() {
        InfoMan.inst.txtInfo.text = description;
        outline.enabled = true;
    }

    public void Hide() {
        InfoMan.inst.txtInfo.text = "";
        outline.enabled = false;
    }
}
