using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {

    public GameObject fadeScreen, startPanel;

	void Start () {
        fadeAnimOn();
        showMouse();

        StartCoroutine(showStartPanel());
	}

    public void hideMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void showMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void deco()
    {
        Application.LoadLevel(1);
    }

    public void fadeAnimOn()
    {
        fadeScreen.GetComponent<Animation>().Play("fadeAnimOn");
    }

    public void fadeAnimOff()
    {
        fadeScreen.GetComponent<Animation>().Play("fadeAnimOff");
    }

    public IEnumerator showStartPanel()
    {
        yield return new WaitForSeconds(2.5f);
        startPanel.SetActive(true);
    }

    public void highScores()
    {
        //Application.OpenURL("https://www.parallelogram.eu/rocketz/highscores.html");
        Application.ExternalEval("window.open(\"https://www.parallelogram.eu/rocketz/highscores.html\",\"_blank\")");
        
    }
}
