using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedScript : MonoBehaviour
{
    SphereScript sphereScript;
    MainMenuScript mainMenu;
/*    bool flagMute;
*/    // Start is called before the first frame update
    void Start()
    {
        sphereScript = GameObject.FindObjectOfType<SphereScript>();
        mainMenu = GameObject.FindObjectOfType<MainMenuScript>();
/*        flagMute = mainMenu.GetMuteStatus();
*/
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "Sphere")
        {
            return;
        }
        //add score to the player
        GameController.inst.IncrementRedScore();
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
