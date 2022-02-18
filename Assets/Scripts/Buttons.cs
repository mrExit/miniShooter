using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField] GameObject _ButtonsMenu;
    private bool _paused;
   
   public void ClickMenu()
    {
        
            Time.timeScale = 0;
            _ButtonsMenu.SetActive(true);     
    }
    public void ClickReturn()
    {
        Time.timeScale = 1;
        _ButtonsMenu.SetActive(false);
    }
    public void ClickRestart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ClickExit()
    {
        Application.Quit();
    }
}
