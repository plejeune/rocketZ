using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    public GameObject controller, victoryPanel;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //victory
            victory();
        }
    }

    public void victory()
    {
        victoryPanel.SetActive(true);
        controller.GetComponent<UserController>().OnGetScore();
    }

}
