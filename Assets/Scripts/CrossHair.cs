using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHair : MonoBehaviour
{
    // Start is called before the first frame update
    public RectTransform crosshair;
    public GameObject player;
    public gameController GC;
    void Start()
    {
        player = GameObject.Find("Player");
        crosshair.position = player.transform.position;
        
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!GC.isPause){
            Cursor.visible = false;
            crosshair.position = Input.mousePosition;
        }
        else{
            Cursor.visible = true;
        }
    }
}
