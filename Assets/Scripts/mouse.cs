using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse : MonoBehaviour
{
    private GameObject player;
    public GameObject bullet;
    public gun Gun;
    private GameObject temp;
    public gameController GC;
    public GameObject bulletSpawn;
    public Animator anim;
    public bool allowFire;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        allowFire = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!GC.waitAnim && !GC.isPause){
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = worldPosition - player.transform.position;
            bulletSpawn.transform.position = player.transform.position;
            if (direction.x > 0){
                player.transform.localScale = new Vector3(10, 10, 1);
            }
            else if (direction.x < 0){
                player.transform.localScale = new Vector3(-10, 10, 1);
            }

            if (Input.GetMouseButton(0) && GC.isPause == false && allowFire){
                temp = Instantiate(bullet, bulletSpawn.transform);
                temp.transform.localScale = new Vector3(5f, 5f, 1f);
                Gun = temp.GetComponent<gun>();
                Gun.Create(direction, 15);
                allowFire = false;
                StartCoroutine(waitNextBullet());
            }
        }
    }
    
    private IEnumerator waitNextBullet()
    {
        yield return new WaitForSeconds(0.175f);
        allowFire = true;
    }
}
