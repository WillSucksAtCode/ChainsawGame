using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPowa : MonoBehaviour
{
    public int sceneNumber;

    public void Quit()
    {
        Debug.Log("*augh*");
        Application.Quit();
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneNumber);
    }

}
