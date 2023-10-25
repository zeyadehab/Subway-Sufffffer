using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    int redScore = 0;
    int blueScore = 0;
    int greenScore = 0;
    public static int totalScore = 0;
    bool flagMute;
    bool flag = false;
    public bool blueshield = false;
    SphereScript sphereScript;
    MainMenuScript mainMenu;

    public static GameController inst;
    public GameObject PausePanel;
    public Text redScoreText;
    public Text blueScoreText;
    public Text greenScoreText;
    public Text totalScoreText;

    public Text GameOverText;


    public void IncrementRedScore()
    {
        if(flag == false)
        {
            if (sphereScript.GetSphereColor() == Color.red)
            {
                totalScore += 2;
                totalScoreText.text = "Total Score: " + totalScore;
            }
            else
            {
                totalScore++;
                totalScoreText.text = "Total Score: " + totalScore;
            }

            if (redScore < 5 && (sphereScript.GetSphereColor() != Color.red))
            {
                redScore++;
                redScoreText.text = "Red Score: " + redScore;

            }
        }
        else
        {
                flag = false;
                totalScore += 5;
                totalScoreText.text = "Total Score: " + totalScore;

                if (redScore < 5 )
                {
                    redScore += 2;
                    if (redScore == 6)
                    {
                        redScore = 5;
                    }
                    redScoreText.text = "Red Score: " + redScore;

                }
            FindObjectOfType<SoundsManager>().StopSound("Jet");


        }

    }    
    public void IncrementBlueScore()
    {
        if(flag == false)
        {
            if (sphereScript.GetSphereColor() == Color.blue)
            {
                totalScore += 2;
                totalScoreText.text = "Total Score: " + totalScore;
            }
            else
            {
                totalScore++;
                totalScoreText.text = "Total Score: " + totalScore;
            }

            if (blueScore < 5 && (sphereScript.GetSphereColor() != Color.blue))
            {
                blueScore++;
                blueScoreText.text = "Blue Score: " + blueScore;

            }
        }
        else
        {
                flag = false;
                totalScore += 5;
                totalScoreText.text = "Total Score: " + totalScore;

                if (blueScore < 5 )
                {
                    blueScore+=2;
                    if (blueScore == 6)
                    {
                        blueScore = 5;
                    }
                    blueScoreText.text = "Blue Score: " + blueScore;

                }
            FindObjectOfType<SoundsManager>().StopSound("Jet");

        }



    }    
    public void IncrementGreenScore()
    {
        if(flag == false)
        {
            if ((sphereScript.GetSphereColor() == Color.green))
            {
                totalScore += 2;
                totalScoreText.text = "Total Score: " + totalScore;
            }
            /*        else if ((sphereScript.GetSphereColor() == Color.green) && flag == true)
                    {
                        flag = false;
                        totalScore+=10;
                        totalScoreText.text = "Total Score: " + totalScore;
                    }   */
            else
            {
                totalScore++;
                totalScoreText.text = "Total Score: " + totalScore;
            }

            if (greenScore < 5 && (sphereScript.GetSphereColor() != Color.green))
            {
                greenScore++;
                greenScoreText.text = "Green Score: " + greenScore;


            }

        }
        else
        {
                flag = false;
                totalScore += 10;
                totalScoreText.text = "Total Score: " + totalScore;
            FindObjectOfType<SoundsManager>().StopSound("Jet");

        }



    }


    private void Awake()
    {
        inst = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        sphereScript = GameObject.FindObjectOfType<SphereScript>();
        mainMenu = GameObject.FindObjectOfType<MainMenuScript>();

    }
    public bool ActivatedObstacleShield()
    {
        return blueshield;
    }
    public void SetActivatedObstacleShieldToFalse()
    {
        blueshield = false ;
    }
    void redPower()
    {
        if (MainMenuScript.mute == false)
        {
            FindObjectOfType<SoundsManager>().PlaySound("Jet");

        }



        redScore--;
        if (redScore == 0)
        {
            sphereScript.ChangeSphereColor(Color.white);

        }
        redScoreText.text = "Red Score: " + redScore;
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        GameObject[] obstacles1 = GameObject.FindGameObjectsWithTag("RedPrefab");
        GameObject[] obstacles2 = GameObject.FindGameObjectsWithTag("BluePrefab");
        GameObject[] obstacles3 = GameObject.FindGameObjectsWithTag("GreenPrefab");

        foreach (GameObject obstacle in obstacles)
        {
            Destroy(obstacle);
        }
        foreach (GameObject obstacle in obstacles1)
        {
            Destroy(obstacle);
        }
        foreach (GameObject obstacle in obstacles2)
        {
            Destroy(obstacle);
        }
        foreach (GameObject obstacle in obstacles3)
        {
            Destroy(obstacle);
        }
        Invoke("StopJetSound", 2);
    }
    void StopJetSound (){
        FindObjectOfType<SoundsManager>().StopSound("Jet");

    }
    void greenPower()
    {
        if (flag == false)
        {
            greenScore--;
            if (MainMenuScript.mute == false)
            { 
            FindObjectOfType<SoundsManager>().PlaySound("Jet");
            }

            if (greenScore == 0)
            {
                sphereScript.ChangeSphereColor(Color.white);

            }
            greenScoreText.text = "Green Score: " + greenScore;
            flag = true;
        }
        else
        {
            if (MainMenuScript.mute == false)
            {
                FindObjectOfType<SoundsManager>().PlaySound("InvalidSelection");
            }

        }


    }
    void bluePower()
    {
        if(blueshield == false)
        {
            blueScore--;
            if (MainMenuScript.mute == false)
            {
                FindObjectOfType<SoundsManager>().PlaySound("Jet");
            }
            if (blueScore == 0)
            {
                sphereScript.ChangeSphereColor(Color.white);

            }
            blueScoreText.text = "Blue Score: " + blueScore;
            blueshield = true;
        }
        else
        {
            if (MainMenuScript.mute == false)
            {
                FindObjectOfType<SoundsManager>().PlaySound("InvalidSelection");
            }
    }


    }
    public void Restart()
    {
        Time.timeScale = 1;
        GameController.totalScore = 0;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }   
    public void Resume()
    {
        Time.timeScale = 1;

        PausePanel.SetActive(false);
        if (MainMenuScript.mute == false)
        {
            FindObjectOfType<SoundsManager>().PlaySound("MainTheme");
        }
        FindObjectOfType<SoundsManager>().StopSound("Steps");



    }
    public void MainMenu()
    {
        GameController.totalScore = 0;

        SceneManager.LoadScene("Menu");

    }
    // Update is called once per frame
    void Update()
    {
        GameOverText.text = totalScoreText.text;
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (redScore == 5)
            {
                if (MainMenuScript.mute == false)
                {
                    FindObjectOfType<SoundsManager>().PlaySound("Switch");
                }

                flag = false;
                blueshield = false;
                redScore--;
                sphereScript.ChangeSphereColor(Color.red);
                redScoreText.text = "Red Score: " + redScore;
                FindObjectOfType<SoundsManager>().StopSound("Jet");

            }
            else
            {
                if (MainMenuScript.mute == false)
                {
                    FindObjectOfType<SoundsManager>().PlaySound("InvalidSelection");
                }

            }
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            if (greenScore == 5)
            {
                if (MainMenuScript.mute == false)
                {
                    FindObjectOfType<SoundsManager>().PlaySound("Switch");
                }
                greenScore--;
                blueshield = false;
                sphereScript.ChangeSphereColor(Color.green);
                greenScoreText.text = "Green Score: " + greenScore;
                FindObjectOfType<SoundsManager>().StopSound("Jet");
            }
            else
            {
                if (MainMenuScript.mute == false)
                {
                    FindObjectOfType<SoundsManager>().PlaySound("InvalidSelection");
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            if (blueScore == 5)
            {
                if (MainMenuScript.mute == false)
                {
                    FindObjectOfType<SoundsManager>().PlaySound("Switch");
                }
                flag = false;
                blueScore--;
                sphereScript.ChangeSphereColor(Color.blue);
                blueScoreText.text = "Blue Score: " + blueScore;
                FindObjectOfType<SoundsManager>().StopSound("Jet");

            }
            else
            {
                if (MainMenuScript.mute == false)
                {
                    FindObjectOfType<SoundsManager>().PlaySound("InvalidSelection");
                }
                

            }
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            if(sphereScript.GetSphereColor() == Color.red)
            {
                redPower();
            }
            else if (sphereScript.GetSphereColor() == Color.green)
            {
                greenPower();
            }else if(sphereScript.GetSphereColor() == Color.blue)
            {
                bluePower();
            }
            else
            {
                if (MainMenuScript.mute == false)
                {
                    FindObjectOfType<SoundsManager>().PlaySound("InvalidSelection");
                }

            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!PausePanel.activeSelf)
            {
                Time.timeScale = 0;
                if (MainMenuScript.mute == false)
                {
                    FindObjectOfType<SoundsManager>().PlaySound("Steps");
                }
                FindObjectOfType<SoundsManager>().StopSound("MainTheme");

                PausePanel.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                if (MainMenuScript.mute == false)
                {
                    FindObjectOfType<SoundsManager>().PlaySound("MainTheme");
                }
                FindObjectOfType<SoundsManager>().StopSound("Steps");

                PausePanel.SetActive(false);
            }


        }
    }
}
