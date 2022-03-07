using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorCluster : MonoBehaviour {

    public float speed = 1.0f;
    public float downY = 0.25f;
    public float barrier = 2.0f;

    private bool goingRight = true;
    private int meteors;

    void Start() {
        
        meteors = transform.childCount;
    }

    void Update() {
        
        if (goingRight) {
 
            MoveRight();

        } else {

            MoveLeft();

        }

    }

    private void MoveRight() {

        var pos = transform.position + Vector3.right * speed * Time.deltaTime;

        if (pos.x < barrier) {

            transform.position = pos;

        } else {

            transform.position = transform.position + Vector3.down * downY;
            goingRight = false;

        }
    }

    private void MoveLeft() {

        var pos = transform.position + Vector3.left * speed * Time.deltaTime;

        if (pos.x > barrier * -1) {

            transform.position = pos;

        } else {

            transform.position = transform.position + Vector3.down * downY;
            goingRight = true;

        }

    }

    public void RemoveMeteor() {

        speed = speed + 0.2f;
        meteors--;

        if (meteors == 0) {

            transform.parent.GetComponent<GameController>().EndGame(1);
            
        }

    }

}
