using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ff")]
public class DataForAllProject : ScriptableObject
{
    public int[] questions;
    public int questionNumber = 0;
    public int score = 0;
}
