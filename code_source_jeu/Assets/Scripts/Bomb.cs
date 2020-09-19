using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    public GameObject controller, rocket, rocketObject, explosion, items, deadPanel;

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //boum
            explode();
        }
    }

    public void explode()
    {
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;

        explosion.SetActive(true);
        rocketObject.GetComponent<BoxCollider>().enabled = false;
        rocket.SetActive(false);
        items.SetActive(false);
        deadPanel.SetActive(true);

        controller.GetComponent<UserController>().OnGetScore();

        StartCoroutine(reload());
        
    }

    public IEnumerator reload()
    {
        yield return new WaitForSeconds(3);
        this.gameObject.GetComponent<MeshRenderer>().enabled = true;
    }

}
