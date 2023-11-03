using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void OnClickPlay()
    {
        SceneManager.LoadScene("levelOne");
    }

    public void OnClickHelp()
    {
        SceneManager.LoadScene("help");
    }

    public void OnClickBack()
    {
        SceneManager.LoadScene("mainMenu");
    }

    public void OnClickCredits()
    {
        SceneManager.LoadScene("credits");
    }
    public void OnClickQuit()
    {
        Application.Quit();
    }
}
