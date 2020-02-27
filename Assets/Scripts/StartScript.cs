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
    int questionsCount;
    int allQuestionsCount;

    public Text startText;
  
    public void Start ()
    {
        data.countOfAll = data.questions.Count;
        if ((data.count == 1) || ((data.count > 20) && (data.count % 10 == 1)))
        {
            startText.text = "Тебе будет задано " + data.count.ToString() + " вопрос\nНа каждый вопрос даётся 30 секунд\nЗа правильный ответ даётся 10 баллов\nНажав клавишу U можно получить подсказку 50:50\nУдачи!";
        }
        if (((data.count > 1) && (data.count < 5)) || ((data.count > 20) && (data.count % 10 > 1) && (data.count % 10 < 5)))
        {
            startText.text = "Тебе будет задано " + data.count.ToString() + " вопроса\nНа каждый вопрос даётся 30 секунд\nЗа правильный ответ даётся 10 баллов\nНажав клавишу U можно получить подсказку 50:50\nУдачи!";
        }
        if (((data.count > 4) && (data.count < 21)) || ((data.count > 20) && (data.count % 10 > 4)) || ((data.count > 20) && (data.count % 10 == 0)))
        {
            startText.text = "Тебе будет задано " + data.count.ToString() + " вопросов\nНа каждый вопрос даётся 30 секунд\nЗа правильный ответ даётся 10 баллов\nНажав клавишу U можно получить подсказку 50:50\nУдачи!";
        }
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
