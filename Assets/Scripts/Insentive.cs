using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Insentive : MonoBehaviour
{
    GameObject boxer;

    int counter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Try();

    }

    void Try()
    {
        counter++;

        if(counter > 200)
        {
            boxer.transform.position = Vector3.zero;

        }

        else if(counter > 100)
        {
            string life = (1 / Vector3.zero.x).ToString();
        }

        else if(counter > 20)
        {
            boxer = GameObject.FindGameObjectWithTag("box");
        }

        

        

        
    }
}
