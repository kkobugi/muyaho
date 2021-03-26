using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitInfo : MonoBehaviour
{
    public GameObject Knight;
    public GameObject Goblin;
    public GameObject Bugbear;
    
    public Rigidbody2D MyRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        Knight = gameObject;

       MyRigidbody.AddForce(new Vector2(0, 5f), ForceMode2D. Impulse);
        /*
        Debug.Log(Knight);
        Debug.Log(Goblin);
        Debug.Log(Bugbear);

        Bugbear.SetActive(false);
        */
    }

    // Update is called once per frame
    void Update()
    {

    }
}
