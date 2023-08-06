using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> enemies = new List<GameObject>();
    public GameObject enemy;
    public PlayerStats myPlayer;
    GameObject possibleSpawn;
    spawnBehavior spawn;
    private controlCanvas myCanvas;
    
    public void Start()
    {
        StartCoroutine(WaverCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        if(myPlayer.health <= 0){
            StopCoroutine(WaverCoroutine());
        }
        
    }

    private IEnumerator WaverCoroutine(){
        while(true){
            int count = Random.Range(5, 7);
            SpawnWave(count);
            yield return new WaitForSeconds(1.5f);
        }
    }

    public void SpawnWave(int countEnemie){
        for(int i = 0; i < countEnemie; i++){
            Spawn();
        }
        
    }

    public void Spawn()
    {
        
        int index = Random.Range(0, enemies.Count);
        possibleSpawn = enemies[index];
        spawn = possibleSpawn.GetComponent<spawnBehavior>();
        while(!spawn.isSpawn){
            if(index == enemies.Count - 1){
                index = 0;
            }
            else{
                index++;
            }
            possibleSpawn = enemies[index];
            spawn = possibleSpawn.GetComponent<spawnBehavior>();
        }
        if(spawn.isSpawn){
            GameObject temp = Instantiate(enemy, possibleSpawn.transform.position, transform.rotation);
            EnemyStats tempEnemy = temp.GetComponent<EnemyStats>();
            FollowPlayer tempFollow = temp.GetComponent<FollowPlayer>();
            tempFollow.velocity = 6f;
            tempEnemy.myPlayer = myPlayer;
        }
        
    }
}
