using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundCreator groundCreator;
    public GameObject obstaclePrefab;
    public GameObject redORBPrefab;
    public GameObject greenORBPrefab;
    public GameObject blueORBPrefab;
    private int itemNumber=0;//if 0:obstacle ,1:red,2:blue,3:green
    private int numberOfObstacles = 0;

    // Start is called before the first frame update
    private void Start()
    {
        groundCreator = GameObject.FindObjectOfType<GroundCreator>();

        CreateItems();


    }
    private void OnTriggerExit(Collider other)
    {
        groundCreator.CreateTile();
        
        Destroy(gameObject, 2);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateItems()
    {
        numberOfObstacles = 0;
        // left position in the road : 
        Transform creationPointLeft = transform.GetChild(2).transform;
        // middle position in the road : 
        Transform creationPointMiddle = transform.GetChild(3).transform;
        // right position in the road : 
        Transform creationPointRight = transform.GetChild(4).transform;
        int ItemOrNotLeft = Random.Range(0, 2);
        int ItemOrNotMiddle = Random.Range(0, 2);
        int ItemOrNotRight = Random.Range(0, 2);
        if(ItemOrNotLeft == 0)//create item
        {
            itemNumber = Random.Range(0, 5);
            if(itemNumber == 0)
            {
                if(numberOfObstacles < 2)
                {
                    CreateObstacle(creationPointLeft);
                    numberOfObstacles++;
                }
            }
            else if(itemNumber == 1)
            {
                CreateRedOrb(creationPointLeft);
            }else if(itemNumber == 2)
            {
                CreateBlueOrb(creationPointLeft);
            }else if(itemNumber == 3)
            {
                CreateGreenOrb(creationPointLeft);
            }
        }        
        if(ItemOrNotMiddle == 0)//create item
        {
            itemNumber = Random.Range(0, 5);
            if (itemNumber == 0)
            {
                if (numberOfObstacles < 2)
                {
                    CreateObstacle(creationPointMiddle);
                    numberOfObstacles++;
                }
            }
            else if (itemNumber == 1)
            {
                CreateRedOrb(creationPointMiddle);
            }
            else if (itemNumber == 2)
            {
                CreateBlueOrb(creationPointMiddle);
            }
            else if (itemNumber == 3)
            {
                CreateGreenOrb(creationPointMiddle);
            }
        }        
        if(ItemOrNotRight == 0)//create item
        {
            itemNumber = Random.Range(0, 5);
            if (itemNumber == 0)
            {
                if (numberOfObstacles < 2)
                {
                    CreateObstacle(creationPointRight);
                    numberOfObstacles++;
                }
            }
            else if (itemNumber == 1)
            {
                CreateRedOrb(creationPointRight);
            }
            else if (itemNumber == 2)
            {
                CreateBlueOrb(creationPointRight);
            }
            else if (itemNumber == 3)
            {
                CreateGreenOrb(creationPointRight);
            }
        }

    }

    void CreateObstacle(Transform creationPoint)
    {
        Instantiate(obstaclePrefab, creationPoint.position, Quaternion.identity, transform);
    }
    void CreateRedOrb(Transform creationPoint)
    {
        Instantiate(redORBPrefab, creationPoint.position, Quaternion.identity, transform);
    }
    void CreateGreenOrb(Transform creationPoint)
    {
        Instantiate(greenORBPrefab, creationPoint.position, Quaternion.identity, transform);
    }
    void CreateBlueOrb(Transform creationPoint)
    {
        Instantiate(blueORBPrefab, creationPoint.position, Quaternion.identity, transform);
    }
}
