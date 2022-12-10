using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : FastSingleton<UIController>
{
    [SerializeField] GameObject uiNextLevel;
    [SerializeField] public GameObject uiPlayAgain;
    [SerializeField] public GameObject uiFrameSetting;
    [SerializeField] public GameObject bot;
    [SerializeField] Text levelText;
    public int currentLevel = 1;
    public int randX;
    // Start is called before the first frame update
    void Start()
    {
        uiFrameSetting.SetActive(true);
    }

    private void Update()
    {
        levelText.text = "Level " + currentLevel;
    }

    // Event of the button when clicked
    //public void PlayButton()
    //{
    //    uiMainMenu.gameObject.SetActive(false);
    //    uiFrameSetting.gameObject.SetActive(true);
    //}
    public void NextLevelButton()
    {
        currentLevel++;
        bot.gameObject.GetComponent<BotController>().stepCount++;
        uiNextLevel.gameObject.SetActive(false);
    }

    public void PlayAgainButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    
}
