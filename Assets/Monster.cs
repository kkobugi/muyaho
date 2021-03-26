using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    public GameObject Hero;
    public GameObject Timer;
    public string myName;
    public bool is_Left;
    public int Damage;
    public int Stage;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = new Vector3(9.4f, -2.1f, 0);
        is_Left = true;

        Stage = 1;
    }

    // Update is called once per frame
    void Update()
    {
        float move = Stage * 0.01f;
        if (Hero.GetComponent<Hero>().HP != 0)
        {
            if (Timer.GetComponent<Timer>().Stage_Increase == true)
            {
                Stage++;
            }
            if (is_Left == true)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x - move, gameObject.transform.position.y, 0);
                if (gameObject.transform.position.x < -9.3f)
                {
                    is_Left = false;
                    gameObject.transform.rotation = new Quaternion(0, 1, 0, 0);
                }
            }
            if (is_Left == false)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x + move, gameObject.transform.position.y, 0);
                if (gameObject.transform.position.x > 9.3f)
                {
                    is_Left = true;
                    gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
                }
            }
        }
    }
}
