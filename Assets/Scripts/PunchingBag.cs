using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchingBag : MonoBehaviour
{
    public string boxingGloveTag = "BoxingGlove";
    public float score = 1;
    public SkinnedMeshRenderer punchingBagFace;

    [SerializeField]
    private Material[] faces;

    private int currentFace;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == boxingGloveTag)
        {
            GameManager.IncreaseScore(score);
        }
    }

   public void SetFace()
    {
        currentFace++;

        if(currentFace >= faces.Length)
        {
            currentFace = 0;
        }

        punchingBagFace.material = faces[currentFace];
    }



}
