using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class gameController : MonoBehaviour
{
    // Start is called before the first frame update
    // canvas pauseMenu
    public Canvas menuCanvas;
    public TextMeshProUGUI messageMenu;
    public TextMeshProUGUI score;
    public Button continueButton;
    public Button restartButton;
    public Button quitButton;
    public PlayerStats myPlayer;
    public bool isPause = false;
    public bool end = false; 
    public bool waitAnim = false;
    public int currentHealth;
    public Animator anim;
    public AudioSource audioDead;
    public AudioSource mainSoundtrack;
    public AudioSource deadSoundtrack;
    void Start()
    {
        Time.timeScale = 1;
        waitAnim = false;
        currentHealth = myPlayer.health;
        menuCanvas.enabled = false;
        messageMenu.text = "";
        score.text = "";
        continueButton.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);

        continueButton.onClick.AddListener(() => {
            isPause = false;
            menuCanvas.enabled = false;
            Time.timeScale = 1;
        });
        restartButton.onClick.AddListener(() => {
            isPause = false;
            menuCanvas.enabled = false;
            end = false;
            Time.timeScale = 1;
            Debug.Log("Restart");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        });
        quitButton.onClick.AddListener(() => {
            isPause = false;
            menuCanvas.enabled = false;
            Time.timeScale = 1;
            SceneManager.LoadScene("Menu");
        });

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)){
            Pause();
        }
    }

    public void Pause(){
        if(!end){
            if(isPause){
                Cursor.visible = false;
                isPause = false;
                Time.timeScale = 1;
                menuCanvas.enabled = false;
                messageMenu.text = "";
                continueButton.gameObject.SetActive(false);
                restartButton.gameObject.SetActive(false);
                quitButton.gameObject.SetActive(false);
            }
            else{
                Cursor.visible = true;
                isPause = true;
                Time.timeScale = 0;
                menuCanvas.enabled = true;
                messageMenu.text = "Pause";
                continueButton.gameObject.SetActive(true);
                restartButton.gameObject.SetActive(true);
                quitButton.gameObject.SetActive(true);
            }
        }
    }

    public void Dead(){
        if(myPlayer.health <= 0){

            GameObject.Find("Player").GetComponent<Animator>().SetBool("death", true);
            waitAnim = true;
            StartCoroutine(DeadPlayer());
        }
    }
    public void canvasDead(){
        Cursor.visible = true;
        end = true;
        isPause = true;
        Time.timeScale = 0;
        menuCanvas.enabled = true;
        messageMenu.text = "Game Over";
        score.text = "Kills: " + myPlayer.enemys_defeated;
        continueButton.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
    }

    IEnumerator DeadPlayer()
    {
        mainSoundtrack.Stop();
        audioDead.Play();
        yield return new WaitForSeconds(2f);
        deadSoundtrack.Play();
        canvasDead();
    }
}
