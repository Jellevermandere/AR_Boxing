using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MattController : MonoBehaviour
{
    //************ 0 == Left && 1 == Right *****************//

   
    [Header("TargetTransforms")]
    [SerializeField]
    private GameObject leftHand;
    [SerializeField]
    private GameObject rightHand;
    [SerializeField]
    private Transform basicLeftHand, basicRightHand, upLeftHand, upRightHand;

    [Header("Parameters")]
    [SerializeField]
    private float animationSpeed;
    [SerializeField]
    private float maxTimeBtwnHands, minTimeBtwnHands;
    [SerializeField]
    private float handsUpTime;
    [SerializeField]
    private int scoreIncrease = 1;
    [SerializeField]
    private bool play;

    private bool leftActive, rightActive, leftMoving, rightMoving;
    private float leftProgress, rightProgress;

    private float timeBtwnHands, currentTimeBtwnHands;

    // Start is called before the first frame update
    void Start()
    {
        currentTimeBtwnHands = Random.Range(minTimeBtwnHands, maxTimeBtwnHands);

        if (leftHand)
        {
            leftHand.transform.position = basicLeftHand.position;
            leftHand.transform.rotation = basicLeftHand.rotation;
        }
        if (rightHand)
        {
            rightHand.transform.position = basicRightHand.position;
            rightHand.transform.rotation = basicRightHand.rotation;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (play)
        {
            ActivateRandomPad();
        }
       
    }

    public void PadHit(bool hit)
    {

        GameManager.IncreaseScore(hit? scoreIncrease: -scoreIncrease);
    }

    void ActivateRandomPad()
    {
        timeBtwnHands += Time.deltaTime;
        if(timeBtwnHands > currentTimeBtwnHands)
        {
            int move = Random.Range(0, 3);

            Debug.Log(move + " & " + currentTimeBtwnHands);

            leftMoving  = move == 1 ? false : true;
            rightMoving = move == 0 ? false : true;

            timeBtwnHands = 0f;
            currentTimeBtwnHands = Random.Range(minTimeBtwnHands, maxTimeBtwnHands);
        }


        if (leftMoving)
        {
            AnimateLeft();
        }
        if (rightMoving)
        {
            AnimateRight();
        }
    }

    void AnimateLeft()
    {
        
            
        int direction;
        if (leftActive)
        {
            direction = -1;
        }
        else direction = 1;
        leftProgress += animationSpeed * Time.deltaTime * direction;

        if(leftProgress <= 0 && leftActive)
        {
            leftProgress = 0f;
            leftActive = false;
            leftHand.GetComponentsInChildren<SeperatePad>()[0].isActive = leftActive;
            leftMoving = false;
            leftHand.GetComponentInChildren<SeperatePad>().SetFace();

        }
        else if(leftProgress >= 1 && !leftActive)
        {
            leftProgress = 1f;
            leftActive = true;
            leftHand.GetComponentsInChildren<SeperatePad>()[0].isActive = leftActive;
                
            leftMoving = false;

            Invoke("MoveLeftDown", handsUpTime);
        }

        leftHand.transform.position = Vector3.Slerp(basicLeftHand.position, upLeftHand.position, leftProgress);
        leftHand.transform.rotation = Quaternion.Slerp(basicLeftHand.rotation, upLeftHand.rotation, leftProgress);
        
    }
    void MoveLeftDown()
    {
        leftMoving = true;
    }

    void AnimateRight()
    {
        

        int direction;
        if (rightActive)
        {
            direction = -1;
        }
        else direction = 1;
        rightProgress += animationSpeed * Time.deltaTime * direction;

        if (rightProgress < 0 && rightActive)
        {
            rightProgress = 0f;
            rightActive = false;
            rightHand.GetComponentsInChildren<SeperatePad>()[0].isActive = rightActive;
            rightMoving = false;
            rightHand.GetComponentInChildren<SeperatePad>().SetFace();

        }
        else if (rightProgress > 1 && !rightActive)
        {
            rightProgress = 1f;
            rightActive = true;
            rightHand.GetComponentsInChildren<SeperatePad>()[0].isActive = rightActive;
            rightMoving = false;
            

            Invoke("MoveRightDown", handsUpTime);

        }

        rightHand.transform.position = Vector3.Slerp(basicRightHand.position, upRightHand.position, rightProgress);
        rightHand.transform.rotation = Quaternion.Slerp(basicRightHand.rotation, upRightHand.rotation, rightProgress);
        
    }

    void MoveRightDown()
    {
        rightMoving = true;
    }

    public void NextFace()
    {
        leftHand.GetComponentsInChildren<SeperatePad>()[0].SetFace();
        rightHand.GetComponentsInChildren<SeperatePad>()[0].SetFace();
    }

}
