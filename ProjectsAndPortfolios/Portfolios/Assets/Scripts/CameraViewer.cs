using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CameraViewer : MonoBehaviour
{
    [SerializeField]
    private Button buttonA, buttonB;
    
    public GameObject cameraA, cameraB;
    string lastViewed = "A";
 
    public void SwitchCamera(string _cameraName)
    {
        switch(_cameraName)
        {
            case ("A"):
                cameraA.SetActive(true);
                cameraB.SetActive(false);
                lastViewed = "A";
                break;
            case ("B"):
                cameraA.SetActive(false);
                cameraB.SetActive(true);
                lastViewed = "B";
                break;
            default:
                Debug.Log("Camera name invalid");
                break;

        }
    }

    public void TurnOnScreen()
    {
        if(lastViewed == "A")
        {
            cameraA.SetActive(true);
            cameraB.SetActive(false);
        } else
        {
            cameraA.SetActive(false);
            cameraB.SetActive(true);
        }
    }

    public void TurnOffScreen()
    {
        cameraA.SetActive(false);
        cameraB.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("player"))
        {
            TurnOnScreen();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("player"))
        {
            TurnOnScreen();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("player"))
        {
            if (other.gameObject.tag.Equals("player"))
            {
                TurnOffScreen();
            }
        }
    }

}

