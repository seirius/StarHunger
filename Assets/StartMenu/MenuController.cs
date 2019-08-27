using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuController : MonoBehaviour {

    public void startGame() {
        SceneManager.LoadScene("Game");
        if (PauseController.PAUSED_GAME) {
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02f;
            PauseController.PAUSED_GAME = false;
        }
    }

    public void exitGame() {
        Application.Quit();
    }

}
