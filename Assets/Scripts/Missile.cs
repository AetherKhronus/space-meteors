using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

    public float speed = 10.0f;
    public GameObject explosion;

    void Start() {

    }

    void Update() {
        
        transform.position = transform.position + Vector3.up * speed * Time.deltaTime;

    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.tag == "Meteor") {

            Instantiate(explosion , transform.position , transform.rotation);
            other.GetComponent<Meteor>().Destroy();

        } else if (other.tag == "Meteor Bullet") {

            Instantiate(explosion , transform.position , transform.rotation);
            other.GetComponent<MeteorBullet>().Destroy();

        }

        Destroy(gameObject);
        
    }
}
