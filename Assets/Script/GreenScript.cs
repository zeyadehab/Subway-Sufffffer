using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenScript : MonoBehaviour
{
    SphereScript sphereScript;
    MainMenuScript mainMenu;
    bool flagMute;
    // Start is called before the first frame update
    void Start()
    {
        sphereScript = GameObject.FindObjectOfType<SphereScript>();
        mainMenu = GameObject.FindObjectOfType<MainMenuScript>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "Sphere")
        {
            return;
        }
        //add score to the player
        GameController.inst.IncrementGreenScore();
        if (MainMenuScript.mute == false)
        { 
        FindObjectOfType<SoundsManager>().PlaySound("PickUp");
         }
        //destroy the red orb
        Destroy(gameObject);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
