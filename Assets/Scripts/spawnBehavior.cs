using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isSpawn = true;
    public GameObject spawn;
    void Start()
    {
        spawn = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D col) {
        if (col.gameObject.tag == "wall"){
            spawn.GetComponent<SpriteRenderer>().color = new Color32(52, 236, 19, 255);
            isSpawn = false;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "wall"){
            spawn.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            isSpawn = true;
        }
    }
}
