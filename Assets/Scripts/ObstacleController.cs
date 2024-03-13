using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private PlayerController PlayerController;
    private GameObject playerGO;
    bool hasObstacleUsed;
    // Start is called before the first frame update
    void Start()
    {
        playerGO = GameObject.FindGameObjectWithTag("Player");
        PlayerController = playerGO.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && hasObstacleUsed == false)
        {
            hasObstacleUsed = true;
            Debug.Log("obstacle touched to player");
            PlayerController.TouchedToObstacle();
            // let the player know obstacle touched
        }
    }
}
