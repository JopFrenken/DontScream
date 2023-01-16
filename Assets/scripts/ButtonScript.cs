using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public Button startBtn;
    public Button exitBtn;

/*    void Awake()
    {
        startBtn.onClick.AddListener(StartGame);
        exitBtn.onClick.AddListener(ExitGame);
    }*/

    public static void StartGame() // (re)starts game
    {
        SceneManager.LoadScene("SampleScene");
    }

    public static void ExitGame()
    {
        Application.Quit();
    }
}
