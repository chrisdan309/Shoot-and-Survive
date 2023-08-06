using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSpawn : MonoBehaviour
{

    // Start is called before the first frame update
    public GameObject player;
    public float angularVelocity;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(player.transform.position, -player.transform.forward, angularVelocity * Time.deltaTime);
    }
}
