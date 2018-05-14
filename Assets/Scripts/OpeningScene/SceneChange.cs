using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChange : MonoBehaviour
{
    public void Update()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }
    public void ChangeScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}