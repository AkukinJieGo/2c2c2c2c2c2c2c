using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start01 : MonoBehaviour
{
    
    
    void Start() {
    
    }
    void Update()
    {
        
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
    
}
