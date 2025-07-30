using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            ReturnToMainMenu();
        }

        if (Input.GetButtonDown("Enter"))
        {
            StartGame();
        }

        if (Input.GetButtonDown("Cancel"))
        {
            QuitGame();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level_0");
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
