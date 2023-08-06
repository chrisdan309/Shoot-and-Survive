using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
    public int max_health = 3;
    public int enemys_defeated;
    public gameController GC;
    void Start()
    {
        enemys_defeated = 0;
        health = max_health;
    }
    
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.Q) && health > 0 && GC.isPause == false){
        //     health--;
        // }
        // if(Input.GetKeyDown(KeyCode.E) && health < 3 && GC.isPause == false){
        //     health++;
        // }
    }

    private void OnCollisionEnter2D(Collision2D other){
        if(other.collider.CompareTag("Enemy")){
            this.gameObject.layer = LayerMask.NameToLayer("Invincibility");
            health--;
            if(health>0)
            {
                StartCoroutine(EnableCollision(1.5f));
            }
            GC.Dead();
        }
    }
    private IEnumerator EnableCollision( float delay )
    {
        Color originColor = GetComponent<SpriteRenderer>().color;
        for(int i = 0; i < delay/0.2; i++){
            GetComponent<SpriteRenderer>().color = new Color(originColor.r, originColor.g, originColor.b, 160f/255f);
            yield return new WaitForSeconds(0.1f);
            GetComponent<SpriteRenderer>().color = new Color(originColor.r, originColor.g, originColor.b, 255f);
            yield return new WaitForSeconds(0.1f);
        }
        this.gameObject.layer = LayerMask.NameToLayer("Player");
    }
}
