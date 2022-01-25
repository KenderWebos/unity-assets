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
                Destroy(GameObject.Find("GameManager"));
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Confined;
                SceneManager.LoadScene(sceneName);

            }
            else
            {
                Destroy(GameObject.Find("GameManager"));
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene(sceneName);
            }
        }
        else
        {
            Application.Quit();
        }

        

    }

}
