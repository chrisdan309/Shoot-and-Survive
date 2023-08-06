using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    Vector2 position;
    Rigidbody2D rbd;
    float velocity;
    bool band;
    public AudioSource hitSound;
    

    public void Create(Vector2 p, float v){
        position = p;
        velocity = v;
        band = true;
    }

    void Movement(){
        rbd.velocity = position.normalized*velocity;
    }

    private void OnCollisionEnter2D(Collision2D other){
        if(other.collider.CompareTag("Enemy") || other.collider.CompareTag("wall")){
            if(other.collider.CompareTag("Enemy")){
                hitSound.Play();
                StartCoroutine(wait());
            }
            else{
                Destroy(gameObject);
            }
            
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(band){
            Movement();
        }
    }
    IEnumerator wait(){
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
