using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ScannableObject", order = 1)]
public class ScannableScriptableObject : ScriptableObject
{
    public float size;
    public string color;
    public string shape;
    public float weight;

}
