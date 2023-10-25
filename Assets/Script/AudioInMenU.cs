using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioInMenU : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (MainMenuScript.mute == false)
        {
            FindObjectOfType<SoundsManager>().PlaySound("Steps");
        }
    }

}
