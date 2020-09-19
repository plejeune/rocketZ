using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterRocket : MonoBehaviour {

    private bool isTriggered1 = false; //if anonym
    private bool isTriggered2 = false; //if logged

    public GameObject player, infoText, panel, ticket, world, race, rocket, rocketObject;
    public GameObject fadeScreen, logBtn, flyBtn, infoBtn, linkBtn, items;
    public Text newScoreText;

    void Update () {

        if(isTriggered1)
        {
            panel.SetActive(true);
            infoText.GetComponent<TextMesh>().text = "Vous devez prendre\nun ticket.";
        }

        if (isTriggered2)
        {
            panel.SetActive(true);
            infoText.GetComponent<TextMesh>().text = "Appuyez sur Espace\npour piloter.";

            if(Input.GetKeyDown(KeyCode.Space))
            {
                //go pilot
                StartCoroutine(goPilot());
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (ticket.activeSelf == true)
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
            isTriggered1 = false;
            isTriggered2 = false;
            infoText.GetComponent<TextMesh>().text = "";
            panel.SetActive(false);
        }
    }

    public IEnumerator goPilot()
    {
        fadeScreen.GetComponent<Animation>().Play("fadeAnimOff");

        yield return new WaitForSeconds(3);

        UserController.newScore = 0;
        newScoreText.text = "" + UserController.newScore;

        items.SetActive(true);
        items.GetComponent<Animation>().Play("trevelling");
        rocket.SetActive(true);
        rocketObject.GetComponent<BoxCollider>().enabled = true;
        logBtn.SetActive(false);
        infoBtn.SetActive(false);
        linkBtn.SetActive(false);
        flyBtn.SetActive(true);
        world.SetActive(false);
        race.SetActive(true);
        player.SetActive(false);
        fadeScreen.GetComponent<Animation>().Play("fadeAnimOn");
    }

}
