using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCreator : MonoBehaviour
{
    public GameObject groundtile;
    Vector3 nextGroundPosition;

    public void CreateTile()
    {

        GameObject temp = Instantiate(groundtile, nextGroundPosition, Quaternion.identity);
        nextGroundPosition = temp.transform.GetChild(1).transform.position;
    }

    // Start is called before the first frame update
    private void Start()
    {

        for (int i = 0;i<5 ; i++)
        {
            CreateTile();
        }

    }



}
