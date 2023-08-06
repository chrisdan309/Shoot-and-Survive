using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float velocity = 5;
    public Rigidbody2D rbd;
    public float axisX;
    public float axisY;
    public Animator anim;
    public gameController GC;
    // Start is called before the first frame update
    void Start(){
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update(){
        if(!GC.waitAnim && !GC.isPause){
            axisX = Input.GetAxisRaw("Horizontal");
            axisY = Input.GetAxisRaw("Vertical");
            Vector2 mov = new Vector2(axisX, axisY).normalized*velocity;
            rbd.velocity = new Vector3(mov.x, mov.y);
            anim.SetFloat("velocity", rbd.velocity.magnitude);
            // if(Input.GetKeyDown(KeyCode.T)){
            //     anim.Play("Dead");
            // }
        }
        else{
            if(GC.waitAnim){
                this.gameObject.layer = LayerMask.NameToLayer("Invincibility");      
            }
            rbd.velocity = new Vector3(0, 0);  
        }
    }
}
