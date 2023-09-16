using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        totalScore = 0;
        _mainMenuButton = GameObject.Find("MainMenuButton");
        _mainMenuButton.SetActive(false);
    }


    private GameObject _section;
    public int totalScore;
    private GameObject _mainMenuButton;

    public void ScoreBoardUpdate(int frame, int attempt, int currentScore, int preScore)
    {
        // (frame * 10) + attempt <- it is ScoreBorad section name
        _section = GameObject.Find(((frame * 10) + attempt).ToString());
        string addText = "";

        if(currentScore == 0) // Gutter
        {
            addText = "-";
        }
        else if(currentScore == 10) // Spare or Strike
        {
            if(attempt == 1)
            {
                addText = "X";
            }
            else
            {
                addText = "/";
                
            }
            
        }
        else // else case
        {
            if(attempt == 1)
            {
                addText = currentScore.ToString();
            }
            else
            {
                addText = (currentScore - preScore).ToString();
            }
            
        }

        _section.GetComponent<TMP_Text>().text = addText;

        // total score update
        if (attempt == 2)
        {
            totalScore += currentScore;
            _section = GameObject.Find((frame * 10).ToString());
            _section.GetComponent<TMP_Text>().text = totalScore.ToString();
        }
        

    }
    
    public void GameEndUI()
    {
        
        _mainMenuButton.SetActive(true);
        GameObject.Find("TotalScore").GetComponent<TMP_Text>().text = "Total  " + totalScore.ToString();
    }
}
