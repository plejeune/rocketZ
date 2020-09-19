using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class drop : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "folder")
        {
            Debug.Log("oooh!");
            this.gameObject.SetActive(false);
        }
    }

    public void okay()
    {
        Debug.Log("okayyy!");
    }

}
