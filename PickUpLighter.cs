using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpLighter : MonoBehaviour
{

    public GameObject LighterOnPlayer;

    // Start is called before the first frame update
    void Start()
    {
        LighterOnPlayer.SetActive(false);
    }


    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                this.gameObject.SetActive(false);
                LighterOnPlayer.SetActive(true);
            }
        }
    }
}
