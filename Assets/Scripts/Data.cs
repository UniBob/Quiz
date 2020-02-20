using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data")]
public class Data : ScriptableObject
{
    public string questionText;
    public string[] answers = new string[4];
    public int rightAnswer;
}