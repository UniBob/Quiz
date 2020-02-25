using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
//using System;

public class StartScript : MonoBehaviour
{
    public DataForAllProject data;
    List<int> questionsSequence = new List<int>();
    int stopper;
    int questionsCount;
    int allQuestionsCount;
  
    public void Test ()
    {
        Ramdomizator();
    }

    public void StartGame()
    {
        questionsCount = data.count;
        allQuestionsCount = data.countOfAll;
        Ramdomizator();
        data.questionsSequence = questionsSequence;
        SceneManager.LoadScene(1);
    }

   
    public void QuitGame()
    {
        Application.Quit();
    }

    void Ramdomizator()
    {
        for (int i = 0; i < questionsCount; i++)
            questionsSequence.Add(i);

        questionsSequence = questionsSequence.OrderBy((item) => Random.value).ToList();
        data.questions = data.questions.OrderBy((item) => Random.value).ToList();


        //System.Random rnd = new System.Random();
        //for (int i = 0; i < questionsCount; i++) 
        //{
        //    bool tmp = true;
        //    var tmpInt = new int();
        //    while(tmp)
        //    {
        //        tmp = false;
        //        tmpInt = rnd.Next(allQuestionsCount);
        //        foreach(int j in questionsSequence)
        //        {
        //            if (j == tmpInt) tmp = true;
        //        }
        //    }
        //    questionsSequence.Add(tmpInt);
        //}
        //int factor = mathFact(allQuestionsCount, questionsCount);
        //stopper = UnityEngine.Random.Range(0, factor);
        
        //while (stopper > 0)
        //{               
        //    stopper--;
        //    for (int i = questionsCount - 1; i >= 0; i--)
        //        if (questionsSequence[i] < allQuestionsCount - questionsCount + i)
        //        {
        //            questionsSequence[i]++;
        //            for (int j = i + 1; j < questionsCount; j++)
        //                questionsSequence[j] = questionsSequence[j - 1] + 1;
        //        }
        //        else break;
        //}
    }

    int mathFact(int n, int k)
    {
        double answer = 1; ;
        for (int i = 1; i<=n;i++)
        {
            answer *= i;
            if (i <= k) answer /= i;
            if (i <= (n - k)) answer /= i;
        }
        //Debug.Log(answer.ToString());
        if (answer > int.MaxValue)
        {
            return int.MaxValue;
        }
        else
        {
            return (int)answer;
        }
    }
}
