using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    public DataForAllProject data;
    int[] questionsSequence;
    int stopper;

    //public Text testText;

    public int questionsCount;
    public int allQuestionsCount;


    public void Test ()
    {
        Ramdomizator();
       // testText.text = stopper.ToString();
    }

    public void StartGame()
    {
        questionsSequence = new int[questionsCount];
        Ramdomizator();
        data.questions = questionsSequence;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void Ramdomizator()
    {
        for (int i = 0; i < questionsCount; i++) 
        {
            questionsSequence[i] = i;
        }
        int factor = mathFact(allQuestionsCount, questionsCount);
        stopper = Random.Range(0, factor);
       // testText.text = stopper.ToString();
        while (stopper > 0)
        {   
            
            stopper--;
            questionsSequence[questionsCount - 1]++;

            for (int i = questionsCount - 1; i > -1; i--) 
            {
                if (questionsSequence[i] >= allQuestionsCount)
                {
                    questionsSequence[i] %= allQuestionsCount;
                    questionsSequence[i - 1]++;
                }
            }
        }
    }

    int mathFact(int n, int k)
    {
        double answer = 1; ;
        for (int i = 1; i<=n;i++)
        {
            answer *= i;
            if (i <= k) answer /= i;
            //if (i <= (n - k)) answer /= i;
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
