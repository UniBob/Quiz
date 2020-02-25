using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalScript : MonoBehaviour
{

    public Text scoreText;
    public DataForAllProject data;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = data.score.ToString();
    }

    // Update is called once per frame
    public void mainMenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void exitButton()
    {
        Application.Quit();
    }
}
