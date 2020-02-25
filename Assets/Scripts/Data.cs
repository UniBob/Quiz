using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data")]
public class Data : ScriptableObject
{
    [TextArea(minLines: 1, maxLines: 10)] public string questionText;
    public string[] answers = new string[4];
    public int rightAnswer;
    public int[] answerFontSize = new int[4];
}