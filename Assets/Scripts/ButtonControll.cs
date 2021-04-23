using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControll : MonoBehaviour
{
    void Start()
    {
        Application.targetFrameRate = 60;
    }
    public void OnClick()
    {
        SceneManager.LoadScene("GameScene");
    }
}
