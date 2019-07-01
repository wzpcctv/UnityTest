using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class UnitData
{
    public string name { get; set; }
    public List<string> drop { get; set; }
    public string spritePath { get; set; }
    public float hp { get; set; }
    public float mp { get; set; }
    public float atk { get; set; }
    public float def { get; set; }
    public int blockUnit { get; set; }
    public int blockBrick { get; set; }
    public bool fly { get; set; }
    public string weapon { get; set; }
}