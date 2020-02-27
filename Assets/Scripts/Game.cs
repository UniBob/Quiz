using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{

    public DataForAllProject data;

    public Image answer;

    public Text timerText;
    string beginningOfTimer = "Осталось ";
    string endingOfTimer = " секунд";
    int timer;
    bool isTimerStarted = true;

    public Text questText;
    public Text scoreText;
    public Button[] buttons = new Button[4];
    bool deleteVariants = false;
    int rightVariant = 0;

    public void Start()
    {
        
        data.score = 0;
        data.questionNumber = 0;
        UpdateText();
        
    }

    
    public void buttonClick(int i)
    {
        isTimerStarted = false;
        if (rightVariant == i)
        {
            RightAnswer();
        }
        else
        {
            WrongAnswer();
        }
    }

    void RightAnswer()
    {
        data.questionNumber++;
        data.score += 10;
        answer.gameObject.SetActive(true);
        answer.GetComponentInChildren<Text>().color = Color.green;
        answer.GetComponentInChildren<Text>().text = "RIGHT";
    }

    void WrongAnswer()
    {
        data.questionNumber++;
        answer.gameObject.SetActive(true);
        answer.GetComponentInChildren<Text>().color = Color.red;
        answer.GetComponentInChildren<Text>().text = "WRONG";
    }

    void TimeIsOver()
    {
        timerText.text = beginningOfTimer + "0" + endingOfTimer;
        data.questionNumber++;
        answer.gameObject.SetActive(true);
        answer.GetComponentInChildren<Text>().color = Color.red;
        answer.GetComponentInChildren<Text>().text = "TIME OVER";
    }

    public void UpdateText()
    {        
        if (data.questionNumber >= data.count)
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                buttons[i].gameObject.SetActive(true);
            }
            deleteVariants = false;
            answer.gameObject.SetActive(false);
            rightVariant = data.questions[data.questionsSequence[data.questionNumber]].rightAnswer;
            questText.text = data.questions[data.questionsSequence[data.questionNumber]].questionText;
            for (int i = 0; i < 4; i++)
            {
                buttons[i].GetComponentInChildren<Text>().text = data.questions[data.questionsSequence[data.questionNumber]].answers[i];
            }
            scoreText.text = data.score.ToString();
            timer = (int)Time.time + 30;
            isTimerStarted = true;
        }
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            if (!deleteVariants) deleteSomeVariants();
        }

        if ((Time.time > timer)&&(isTimerStarted))
        {
            TimeIsOver();
            isTimerStarted = false;
        }
        if (!answer.gameObject.activeSelf) timerText.text = beginningOfTimer + (timer - (int)Time.time).ToString() + endingOfTimer;
    }

    void deleteSomeVariants()
    {
        deleteVariants = true;
        int tmp = 2;
        int prev = 5;
        while (tmp>0)
        {
            int g = Random.Range(0, 3);
            if ((g != rightVariant)&&(g != prev))
            {
                prev = g;
                buttons[g].gameObject.SetActive(false);
                tmp--;
            }
        }
    }
}
