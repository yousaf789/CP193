using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPad : MonoBehaviour
{
    // public Animator door;
    // public GameObject openText;

    // public AudioSource doorSound;

    public GameObject InitialDesign;
    public GameObject SwitchStage;
    public GameObject interactText;

    public bool inReach;




    void Start()
    {
        inReach = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            interactText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            interactText.SetActive(false);
        }
    }





    void Update()
    {

        if (inReach && Input.GetButtonDown("Interact"))
        {
            SwitchStage.SetActive(true);
            InitialDesign.SetActive(false);
            interactText.SetActive(false);
            Color newAmbientColor = new Color(7f / 255f, 7f / 255f, 7f / 255f);


            RenderSettings.ambientLight = newAmbientColor;
        }

        else
        {
            
        }




    }
    // void DoorOpens ()
    // {
    //     // Debug.Log("It Opens");
    //     door.SetBool("Open", true);
    //     door.SetBool("Closed", false);
    //     doorSound.Play();

    // }

    // void DoorCloses()
    // {
    //     // Debug.Log("It Closes");
    //     door.SetBool("Open", false);
    //     door.SetBool("Closed", true);
    // }


}
