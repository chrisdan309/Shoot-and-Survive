using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public float velocity = 10.0f;
    public float norm;
    public Rigidbody2D rbd;
    public EnemyStats myEnemy;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(myEnemy.health > 0)
        {
            Vector2 distance = (player.transform.position - transform.position);
            Vector2 mov = distance.normalized*velocity;
            gameObject.transform.localScale = new Vector3(Mathf.Sign(distance.x)*10, 10, 1);
            rbd.velocity = new Vector2(mov.x, mov.y);
            norm = mov.x*mov.x + mov.y*mov.y;
        }
        if(myEnemy.health <= 0 || player.GetComponent<PlayerStats>().health <= 0)
        {
            GetComponent<Collider2D>().enabled = false;
            rbd.velocity = Vector2.zero;
        }
    }
}
