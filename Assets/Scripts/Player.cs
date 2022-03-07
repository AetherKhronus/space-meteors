using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public float speed = 7.5f;
    public GameObject missile;
    public int health = 3;
    public float fireRate = 0.5f;
    public Text hp;

    private bool canShoot = true;

    void Start() {
        
    }

    void Update() {
        
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {

            MoveLeft();

        } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {

            MoveRight();

        }

        if (Input.GetKey(KeyCode.Space) && canShoot) {

            StartCoroutine(Shoot());

        }

    }

    private void MoveLeft() {

        var mov = transform.position + Vector3.left * speed * Time.deltaTime;

        if (mov.x < -8) {

            mov.x = -8;

        }

        transform.position = mov;
    }

    private void MoveRight() {

        var mov = transform.position + Vector3.right * speed * Time.deltaTime;

        if (mov.x > 8) {

            mov.x = 8;

        }

        transform.position = mov;
    }

    private IEnumerator Shoot() {

        canShoot = false;
        Instantiate(missile , transform.position + Vector3.up , transform.rotation);
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }

    public void TakeHit() {

        health--;

        hp.text = "HP: " + health + "/3";
        
        if (health == 0) {

            transform.parent.GetComponent<GameController>().EndGame(2);
        }

    }

}
