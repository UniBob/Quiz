using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    public int[] questionsSequence;
    public int stopper;

    public Text testText;

    public int questionsCount;
    public int allQuestionsCount;


    public void Test ()
    {
        Ramdomizator();
       // testText.text = stopper.ToString();
    }

    public void StartGame()
    {
        Ramdomizator();
        Game.questions = questionsSequence;
        SceneManager.LoadScene(questionsSequence[0]);
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
        int factorial = mathFact(allQuestionsCount, questionsCount);
        stopper = Random.Range(0, factorial);
        Debug.Log(factorial.ToString());
        testText.text = stopper.ToString();
        int flagJ = 0;
        while (stopper > 0)
        {           
            stopper--;
            flagJ++;
            questionsSequence[questionsCount - 1]++;
            for (int i = questionsCount - 1; i > -1; i--) 
            {
                if ((i == 0) && (questionsSequence[0] == allQuestionsCount))
                {
                    break;
                }
                else
                    if (questionsSequence[i] >= allQuestionsCount) 
                    {
                        questionsSequence[i] %= allQuestionsCount;
                        questionsSequence[i - 1]++;
                    }
                    else
                    {
                        break;
                    }
            }
        }
        Debug.Log(flagJ.ToString());

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
        return (int)answer;
    }
}
