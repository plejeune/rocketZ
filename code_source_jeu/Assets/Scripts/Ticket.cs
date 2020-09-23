using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ticket : MonoBehaviour {

    public bool isTriggered1 = false; //if anonym
    public bool isTriggered2 = false; //if logged

    public GameObject infoText, panel, logBtn, ticket, controller, particles, ticketText;

    void Update () {

        if(isTriggered1)
        {
            panel.SetActive(true);
            infoText.GetComponent<TextMesh>().text = "Connectez-vous pour\nrecevoir un ticket.";
        }

        if (isTriggered2)
        {
            panel.SetActive(true);
            infoText.GetComponent<TextMesh>().text = "Appuyez sur Espace\npour un ticket.";

            if (Input.GetKeyDown(KeyCode.Space))
            {
                //get a ticket
                getTicket();
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (logBtn.activeSelf == true)
            {
                isTriggered2 = true;
            }
            else
            {
                isTriggered1 = true;
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            panel.SetActive(false);
            infoText.GetComponent<TextMesh>().text = "";
            isTriggered1 = false;
            isTriggered2 = false;
        }
    }

    public void getTicket()
    {
        ticket.SetActive(true);
        ticketText.SetActive(true);
        particles.SetActive(true);

        panel.SetActive(false);
        infoText.GetComponent<TextMesh>().text = "";
        isTriggered1 = false;
        isTriggered2 = false;

        this.gameObject.SetActive(false);
    }
}
