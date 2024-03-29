using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class ButtonController : MonoBehaviour
{
    [HideInInspector]
    public Button playBut, restartBut, nextLevelBut;

    public Text scoreText,totalScore;

    [SerializeField] Text levelText;

    public static ButtonController Instance;


    private void Awake()
    {
        Instance = this;

        ButtonReference();     
    }

    private void Start()
    {
        
        levelText.GetComponent<Text>().text = "Level " + (PlayerPrefs.GetInt("Level")+1).ToString();
    }

    public void PlayButton()
    {
        playBut.gameObject.SetActive(false);
        GameManager.Instance.StartMovement();
    }

    public void RestartButton()
    {
        restartBut.gameObject.SetActive(false);
        LevelController.Instance.RestartLevelButton();
        BulletController.scoreAmount = 0;

    }

    public void NextLevelButton()
    {
        LevelController.Instance.NextLevelButton();
        nextLevelBut.gameObject.SetActive(false);
        BulletController.scoreAmount = 0;
        GameManager.Instance.StopMovement();

    }

    public void ButtonReference()
    {
        playBut = transform.GetChild(0).GetComponent<Button>();
        nextLevelBut = transform.GetChild(1).GetComponent<Button>();
        restartBut = transform.GetChild(2).GetComponent<Button>();

    }
}
