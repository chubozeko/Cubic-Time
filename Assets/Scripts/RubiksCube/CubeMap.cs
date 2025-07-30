using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeMap : MonoBehaviour
{
    public CubeState cubeState;

    public Transform up;
    public Transform down;
    public Transform left;
    public Transform right;
    public Transform front;
    public Transform back;

    public List<Image> cubeColours;

    public void Set()
    {
        // cubeState = FindObjectOfType<CubeState>();

        UpdateMap(cubeState.front, front);
        UpdateMap(cubeState.back, back);
        UpdateMap(cubeState.left, left);
        UpdateMap(cubeState.right, right);
        UpdateMap(cubeState.up, up);
        UpdateMap(cubeState.down, down);
    }


    void UpdateMap(List<GameObject> face, Transform side)
    {
        int i = 0;
        foreach (Transform map in side)
        {
            if (face[i].name[0] == 'F')
            {
                // Orange
                // map.GetComponent<Image>().material = cubeColours[0];
                map.GetComponent<Image>().color = cubeColours[0].color; // new Color(1, 0.5f, 0, 1);
            }
            if (face[i].name[0] == 'B')
            {
                // Red
                // map.GetComponent<Image>().material = cubeColours[1];
                map.GetComponent<Image>().color = cubeColours[1].color; // Color.red;
            }
            if (face[i].name[0] == 'U')
            {
                // Yellow
                // map.GetComponent<Image>().material = cubeColours[2];
                map.GetComponent<Image>().color = cubeColours[2].color; // Color.yellow;
            }
            if (face[i].name[0] == 'D')
            {
                // White
                // map.GetComponent<Image>().material = cubeColours[3];
                map.GetComponent<Image>().color = cubeColours[3].color; // Color.white;
            }
            if (face[i].name[0] == 'L')
            {
                // Green
                // map.GetComponent<Image>().material = cubeColours[4];
                map.GetComponent<Image>().color = cubeColours[4].color; // Color.green;
            }
            if (face[i].name[0] == 'R')
            {
                // Blue
                // map.GetComponent<Image>().material = cubeColours[5];
                map.GetComponent<Image>().color = cubeColours[5].color; // Color.blue;
            }
            i++;
        }               
    }
}
