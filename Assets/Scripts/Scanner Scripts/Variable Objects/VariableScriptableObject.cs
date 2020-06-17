using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/VariableObject", order = 2)]
public class VariableScriptableObject : ScriptableObject
{
    public string type;
    public string variableName;
    public string value;
}
