using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {

    public GameObject smallDoor;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            smallDoor.GetComponent<Animation>().Play("smallDoorAnim1");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            smallDoor.GetComponent<Animation>().Play("smallDoorAnim2");
        }
    }
}
