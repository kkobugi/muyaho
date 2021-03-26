using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public Camera c;
    private bool can_jump = false;
    public int HP;
    public bool invince;
    public float invince_timer;
    public float waiting_time;
    public GameObject Heart3;
    public GameObject Heart2;
    public GameObject Heart1;
    public GameObject Heart0;
    public GameObject GameOver;
    // Start is called before the first frame update
    void Start()
    {
        Heart3.SetActive(true);
        Heart2.SetActive(false);
        Heart1.SetActive(false);
        Heart0.SetActive(false);
        GameOver.SetActive(false);
        invince_timer = 0.0f;
        waiting_time = 1.0f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            HP -= collision.gameObject.GetComponent<Monster>().Damage;
            Debug.Log(collision.gameObject.GetComponent<Monster>().myName + HP);

            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(5f, 0), ForceMode2D.Impulse);

            if (HP == 2)
            {
                Heart2.SetActive(true);
                Heart3.SetActive(false);
            }

            if (HP == 1)
            {
                Heart1.SetActive(true);
                Heart2.SetActive(false);
            }

            if (HP == 0)
            {
                Heart0.SetActive(true);
                Heart1.SetActive(false);
                GameOver.SetActive(true);
                gameObject.SetActive(false);
            }
 
        }

        if (collision.gameObject.tag == "Ground")
        {
            can_jump = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            can_jump = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.x < 0f)
            pos.x = 0f;
        if (pos.x > 1f)
            pos.x = 1f;
        if (pos.y < 0f)
            pos.y = 0f;
        if (pos.y > 1f)
            pos.y = 1f;

        transform.position = Camera.main.ViewportToWorldPoint(pos);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + 0.015f, gameObject.transform.position.y, 0);
            gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x - 0.015f, gameObject.transform.position.y, 0);
            gameObject.transform.rotation = new Quaternion(0, 1, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.LeftAlt) && can_jump == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 9f), ForceMode2D.Impulse);
        }
    }
}

