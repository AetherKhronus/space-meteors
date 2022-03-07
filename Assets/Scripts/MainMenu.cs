using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    void Start() {

    }

    void Update() {

        if (Input.GetKeyDown(KeyCode.Escape)) {

            Exit();

        } 

    }

    public void Play() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void Exit() {

        Application.Quit();

    }

    public void PlayAgain() {

        SceneManager.LoadScene("Game");
    }
}
