using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeButtonState : MonoBehaviour
{
    private string face;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetButtonState(string faceName)
    {
        face = faceName;
    }
    public string GetButtonState()
    {
        return face;
    }
}


