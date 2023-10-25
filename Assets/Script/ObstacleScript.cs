using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    SphereScript sphereScript;
    GameController gameContoller;
    MainMenuScript mainMenu;
/*    bool flagMute;
*/    // Start is called before the first frame update
    void Start()
    {
        sphereScript = GameObject.FindObjectOfType<SphereScript>();
        gameContoller = GameObject.FindObjectOfType<GameController>();
        mainMenu = GameObject.FindObjectOfType<MainMenuScript>();

    }
    private void OnCollisionEnter(Collision collision)
    {

        if (MainMenuScript.mute == false)
        {
            FindObjectOfType<SoundsManager>().PlaySound("Hit");
        }
        if ((collision.gameObject.name == "Sphere")&&(sphereScript.GetSphereColor() == Color.white))
        {

            sphereScript.Die();
        }
        else if ((collision.gameObject.name == "Sphere") && (sphereScript.GetSphereColor() != Color.white))
        {
            if (!gameContoller.ActivatedObstacleShield())
            {
                sphereScript.ChangeSphereColor(Color.white);
            }
            else
            {
                gameContoller.SetActivatedObstacleShieldToFalse();
                FindObjectOfType<SoundsManager>().StopSound("Jet");

            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
