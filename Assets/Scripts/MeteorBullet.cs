using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorBullet : MonoBehaviour {

    public float speed = 2.5f;
    public GameObject explosion;

    void Start() {

    }

    void Update() {
        
        transform.position = transform.position + Vector3.down * speed * Time.deltaTime;

    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.tag == "Player") {

            Instantiate(explosion , transform.position , transform.rotation);
            Destroy(gameObject);
            other.GetComponent<Player>().TakeHit();

        } else if (other.tag == "Border") {

            Destroy(gameObject);
        }
        
    }

    public void Destroy() {

        Destroy(gameObject);
    }

}
