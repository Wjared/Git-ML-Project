using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x - transform.position.x > 3)
        {
            transform.position = new Vector3(player.transform.position.x - 3, transform.position.y, transform.position.z);
        }
        else if (transform.position.x - player.transform.position.x > 5)
        {
            transform.position = new Vector3(player.transform.position.x + 5, transform.position.y, transform.position.z);
        }
        if (player.transform.position.y - transform.position.y > 4)
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y - 4, transform.position.z);
        }
        else if (transform.position.y - player.transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
        }
    }
}
