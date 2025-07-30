using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    Automate automate;
    public float shuffleTime = 30f;
    public CubeMap cubeMap;
    public List<MeshRenderer> colourButtonMRs;
    
    public List<Image> cubeFaceLeft;
    public List<AN_Button> colourButtons;
    void Start()
    {
        automate = FindObjectOfType<Automate>();
        InvokeRepeating("ShuffleCube", 1.0f, shuffleTime);
    }

    void Update()
    {
        
    }

    void ShuffleCube()
    {
        Debug.Log("shuffle now");
        automate.Shuffle();
    }

    public void CheckForValidFace()
    {
        int validF = 0;
        // LEFT
        for (int i = 0; i < colourButtonMRs.Count; i++)
        {
            if (colourButtonMRs[i].material.color == cubeMap.left.GetChild(i).GetComponent<Image>().color)
            {
                validF++;
                Debug.Log("VALID color: " + i);
            }
        }
        if (validF == 9)
        {
            Debug.Log("CORRECT FACE");
            // TODO: Add to scoreboard
            // TODO: Reshuffle cube
        }
    }

    /*
    void CheckForValidFace()
    {
        int validF = 0;
        // FRONT
        for (int i=0; i<colourButtonMRs.Count; i++)
        {
            if (colourButtonMRs[i].material.color == cubeMap.front.GetChild(i))
        }
    }
    */
}
