using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ff")]
public class DataForAllProject : ScriptableObject
{
    public List<Data> questions;
    public List<int> questionsSequence;
    public int count;
    public int countOfAll;
    public int questionNumber = 0;
    public int score = 0;
}
