using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    void Start() {
        
    }


    void Update() {
        
        if (Input.GetKeyDown(KeyCode.Escape)) {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            
        } 

    }

    private IEnumerator Finish(int state) {

        yield return new WaitForSeconds(1.5f);

        if (state == 1) {

           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Victory
           
        } else {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2); //Defeat

        }

    }

    public void EndGame(int state) {

        StartCoroutine(Finish(state));

    }

}
