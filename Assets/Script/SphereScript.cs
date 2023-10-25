using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SphereScript : MonoBehaviour
{
    bool alive = true;
    public float SphereSpeed = 1.0f;
    private int getMyNextLane = 1;
    public GameObject gameOverPanel;
    public Text finalScore;

    MainMenuScript mainMenu;

    GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindObjectOfType<GameController>();
        mainMenu = GameObject.FindObjectOfType<MainMenuScript>();
        if (MainMenuScript.mute == false)
        {
            FindObjectOfType<SoundsManager>().PlaySound("MainTheme");

        }
        FindObjectOfType<SoundsManager>().StopSound("Steps");


    }

    // Update is called once per frame
    void Update()
    {

        if (!alive) return;
        transform.Translate(SphereSpeed * Time.deltaTime* (1+GameController.totalScore*0.01f), 0, 0);
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            getMyNextLane--;
            if(getMyNextLane == -1)
            {
                getMyNextLane = 0;
            }
            else
            {
                transform.Translate(0, 0, -1.5f);
            }

        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            getMyNextLane++;
            if (getMyNextLane == 3)
            {
                getMyNextLane = 2;
            }
            else
            {
                transform.Translate(0, 0, 1.5f);
            }

        }
    }
    void FixedUpdate()
    {
 

    }
    public void ChangeSphereColor(Color newColor)
    {
        GameObject.Find("Sphere").GetComponent<Renderer>().material.color = newColor;

    }
    public Color GetSphereColor()
    {
        Color newColor;
        newColor = GameObject.Find("Sphere").GetComponent<Renderer>().material.color ;
        return newColor;

    }
    public void Die()
    {
        if (gameController.ActivatedObstacleShield())
        {
            gameController.SetActivatedObstacleShieldToFalse();
        }
        else
        {
            alive = false;
            GameOver();
        }

    }
    void GameOver()
    {
        GameController.totalScore = 0;
        FindObjectOfType<SoundsManager>().StopSound("MainTheme");
        if (MainMenuScript.mute == false)
        {
            FindObjectOfType<SoundsManager>().PlaySound("Steps");

        }

        gameOverPanel.SetActive(true);

    }
}
