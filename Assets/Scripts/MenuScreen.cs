using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScreen : MonoBehaviour
{
    public string nextScene = "SampleScene";

    public void changeScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene);
    }
}
