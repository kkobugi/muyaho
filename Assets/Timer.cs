using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public GameObject Hero;
    public float Next_Stage;
    public Text text_Timer;
    public bool Stage_Increase;
    public Text text_Stage;
    private int Stage;
    public float Score;
    public Text text_Score;
    public GameObject restart;
    // Start is called before the first frame update
    void Start()
    {
        Stage = 1;
        Next_Stage = 30;
        Stage_Increase = false;
        restart.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Hero.GetComponent<Hero>().HP != 0)
        {
            Next_Stage -= Time.deltaTime;
            text_Timer.text = "다음 스테이지까지 : " + Mathf.Round(Next_Stage);
            text_Stage.text = Stage + " 스테이지";
            Score = Score + (Stage * Time.deltaTime);
            text_Score.text = "점수 : " + Mathf.Round(Score);

            if (Next_Stage <= 0)
            {
                Next_Stage = 30;
                Stage_Increase = true;
                Stage++;
            }
            else
            {
                Stage_Increase = false;
            }
        }
        else
        {
            restart.SetActive(true);
            if(Input.GetKey(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
