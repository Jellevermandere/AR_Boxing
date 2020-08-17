using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeperatePad : MonoBehaviour
{
    public string boxingGloveTag = "BoxingGlove";
    public MeshRenderer bagFace;
    public float scoreIncrease = 1;

    [HideInInspector]
    public bool isActive;

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
        if (collision.collider.tag == boxingGloveTag)
        {
            GameManager.IncreaseScore(isActive ? scoreIncrease : -scoreIncrease);
        }
    }

    public void SetFace()
    {
        currentFace++;

        if (currentFace >= faces.Length)
        {
            currentFace = 0;
        }

        bagFace.material = faces[currentFace];
    }
}
