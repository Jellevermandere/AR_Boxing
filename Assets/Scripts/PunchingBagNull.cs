using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchingBagNull : MonoBehaviour
{
    [SerializeField]
    private PunchingBag bag;
    

    private void Start()
    {
        Vector3 targetDirection = new Vector3(Camera.main.transform.position.x, transform.position.y, Camera.main.transform.position.z);

        transform.LookAt(targetDirection);
    }



    public void SetFace()
    {
        bag.SetFace();
    }
}
