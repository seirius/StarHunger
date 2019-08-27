using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseController : MonoBehaviour {

    public static bool PAUSED_GAME = false;

    public GameObject pauseCanvas;

    public GameObject gameOverCanvas;

    public void resumeGame() {
        PAUSED_GAME = false;
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
        pauseCanvas.SetActive(false);
    }

    public void pauseGame() {
        PAUSED_GAME = true;
        Time.timeScale = 0f;
        Time.fixedDeltaTime = 0f;
    }

    public void startGame() {
        SceneManager.LoadScene("Game");
        resumeGame();
    }

    public void goMenu() {
        SceneManager.LoadScene("Start");
        resumeGame();
    }

    public void exitGame() {
        Application.Quit();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (!PAUSED_GAME) {
                pauseGame();
                pauseCanvas.SetActive(true);
            } else {
                resumeGame();
            }
        }
    }

    public void gameOver() {
        pauseGame();
        if (gameOverCanvas != null) {
            gameOverCanvas.SetActive(true);
        }
    }

}
