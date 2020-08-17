using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxingGloves : MonoBehaviour
{
    public Rigidbody gloveRb;
    public ParticleSystem chargingParticle;
    public float force = 10f;
    public float maxChargeTime = 5f;
    public int mouseButton;
    public bool touchMode;

    private float chargeTime;

    private Vector3 position;
    private float width;
    private float height;

    

    // Start is called before the first frame update
    void Start()
    {
        width = (float)Screen.width / 2.0f;
        height = (float)Screen.height / 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.GameMode == 1)
        {
            TryPunch();
        }
        
    }


    void StopCharging()
    {
        if(chargingParticle)
            chargingParticle.Stop();
    }

    void TryPunch()
    {
        if ((Input.GetMouseButton(mouseButton) && !touchMode) || (touchMode && Input.GetMouseButton(0) && Input.mousePosition.y < height && ((mouseButton == 0 && Input.mousePosition.x < width) || (mouseButton == 1 && Input.mousePosition.x > width))))
        {


            chargeTime += Time.deltaTime;
            if (chargingParticle)
            {
                if (chargeTime > 0.2f && !chargingParticle.isPlaying) chargingParticle.Play();
            }


            if (chargeTime > maxChargeTime) chargeTime = maxChargeTime;
            gloveRb.AddForce(-transform.forward * force * chargeTime * 20f * Time.deltaTime, ForceMode.Acceleration);


        }

        if ((Input.GetMouseButtonUp(mouseButton) && !touchMode) || (touchMode && Input.GetMouseButtonUp(0) && Input.mousePosition.y < height && ((mouseButton == 0 && Input.mousePosition.x < width) || (mouseButton == 1 && Input.mousePosition.x > width))))
        {
            if (chargeTime < 1f) chargeTime = 1f;
            else if (chargeTime > maxChargeTime) chargeTime = maxChargeTime;

            gloveRb.AddForce(transform.forward * force * chargeTime, ForceMode.VelocityChange);

            chargeTime = 0f;

            Invoke("StopCharging", 0.2f);
        }
    }

   
}
