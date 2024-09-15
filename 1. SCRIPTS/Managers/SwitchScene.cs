using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public enum Scene
    {
        GameScene,
    }

    public static void ChangeScene(string sceneName)
    {
        if (sceneName!="exit")
        {
            if (sceneName == "Playground")
            {
                SceneManager.LoadScene(sceneName);

            }
            else
            {
                SceneManager.LoadScene(sceneName);
            }
        }
        else
        {
            Application.Quit();
        }

        

    }

}
