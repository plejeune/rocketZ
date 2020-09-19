using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public GameObject playerSmall, steps, introText, rocket, focus;
    public float moveSpeedX, moveSpeedY;

    void Update () {

        transform.Translate(moveSpeedX * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, moveSpeedY * Input.GetAxis("Vertical") * Time.deltaTime);

        
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            playerSmall.transform.eulerAngles = new Vector3(0, 107.75f, 0);
            steps.SetActive(true);
            introText.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            playerSmall.transform.eulerAngles = new Vector3(0, 287.75f, 0);
            steps.SetActive(true);
            introText.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            playerSmall.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, 197.75f, this.transform.eulerAngles.z);
            steps.SetActive(true);
            introText.SetActive(false);
            rocket.GetComponent<Animation>().Play("rocketTurn2");
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
        {
            rocket.GetComponent<Animation>().Play("rocketTurn2b");
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            playerSmall.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, 17.75f, this.transform.eulerAngles.z);
            steps.SetActive(true);
            introText.SetActive(false);
            rocket.GetComponent<Animation>().Play("rocketTurn1");
        }

        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            rocket.GetComponent<Animation>().Play("rocketTurn1b");
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) ||
            Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            steps.SetActive(false);   
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) ||
            Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            focus.SetActive(false);
        }
    }
}
