using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(gameObject.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (gameObject.transform.position.x < 30)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y, 0);
        }
        */
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("착지");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject+" / "+collision.transform.position);
    }
}
