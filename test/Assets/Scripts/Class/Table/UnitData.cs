using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class UnitData
{
    public int ID { get; set; }
    public string name { get; set; }
    public float hp { get; set; }
    public List<string> drop { get; set; }
    public string spritePath { get; set; }
}