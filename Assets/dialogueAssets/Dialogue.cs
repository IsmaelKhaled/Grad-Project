using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Dialogue  {

    public string name;
    public int panelindex;
    public string panelTagname;

    [TextArea(3,10)]
    public string[] sentences;

    public int buttonsCount;
}
