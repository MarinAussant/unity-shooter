using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class onClick : MonoBehaviour
{
    public string sceneToLoad = "Game";

    public void OnButtonClick()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
