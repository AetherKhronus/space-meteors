using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour {

    public GameObject bullet;
    public GameObject explosion;

    private bool canFire = false;

    void Start() {
        
        StartCoroutine(BeginFiring());
        
    }

    void Update() {
        
        if (canFire) {

            StartCoroutine(Fire());
        }

        if (transform.position.y <= -5f) {

            Destroy();

        }

    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.tag == "Player") {

            Instantiate(explosion , transform.position + new Vector3(-0.1f , 0.1f , 0) , transform.rotation);
            Instantiate(explosion , transform.position + new Vector3(0 , 0.2f , 0) , transform.rotation);
            Instantiate(explosion , transform.position + new Vector3(0.1f , 0.1f , 0) , transform.rotation);
            Destroy(gameObject);
            other.GetComponent<Player>().TakeHit();

        }

    }

    private IEnumerator BeginFiring() {

        yield return new WaitForSeconds(Random.Range(0.1f , 7.6f));
        canFire = true;

    }

    private IEnumerator Fire() {

        canFire = false;
        Instantiate(bullet , transform.position + Vector3.down , transform.rotation);
        yield return new WaitForSeconds(Random.Range(1.5f , 7.6f));
        canFire = true;

    }

    public void Destroy() {

        transform.parent.GetComponent<MeteorCluster>().RemoveMeteor();
        Destroy(gameObject);

    }

}
