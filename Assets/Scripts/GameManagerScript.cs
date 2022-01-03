using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject restartButton;
    public GameObject titleButton;
    public Text gameEndText;
    public PlayerScript player;
    public GameObject enemys;
    private Transform enemyTransform;

    // Start is called before the first frame update
    void Start()
    {
        restartButton.SetActive(false);
        titleButton.SetActive(false);
        gameEndText.text = "";
        enemyTransform = enemys.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null)
        {
            gameEndText.text= "ゲームオーバー";
            restartButton.SetActive(true);
            titleButton.SetActive(true);
        }
        else if(enemyTransform.childCount == 0)
        {
            gameEndText.text= "ゲームクリアー";
            restartButton.SetActive(true);
            titleButton.SetActive(true);
        }
    }

    public void OnClickRestart()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnClickTitle(){
        SceneManager.LoadScene("TitleScene");
    }
}
