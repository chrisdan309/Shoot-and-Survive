using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int health = 2;
    public PlayerStats myPlayer;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        health = 2;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Bullet"))
        {
            health -= 1;
            if (health <= 0)
            {
                GetComponent<Collider2D>().enabled = false;
                anim.Play("Dead");
                myPlayer.enemys_defeated++;
                StartCoroutine(DestroyObject());
                
                
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
    }
    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(1.2f);
        Destroy(gameObject);
    }
}
