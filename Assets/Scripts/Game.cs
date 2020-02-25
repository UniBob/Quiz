using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{

    public DataForAllProject data;

    public Image answer;

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
        }
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            if (!deleteVariants) deleteSomeVariants();
        }
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
