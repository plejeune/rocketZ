using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpecial : MonoBehaviour {

    public GameObject controller;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //pick up
            pickUp();
        }
    }

    public void pickUp()
    {
        controller.GetComponent<UserController>().winPointSpecial();
        controller.GetComponent<UserController>().Save();

        this.gameObject.GetComponent<MeshRenderer>().enabled = false;

        StartCoroutine(reload());
    }

    public IEnumerator reload()
    {
        yield return new WaitForSeconds(4);
        this.gameObject.GetComponent<MeshRenderer>().enabled = true;
    }
}
