using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{

    public void ReTry()
    {
        Time.timeScale = 1f;
        ShipCtrl.Instance.DamageReceiver.Reborn();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        ShipCtrl.Instance.DamageReceiver.Reborn();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
