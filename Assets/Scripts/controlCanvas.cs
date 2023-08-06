using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class controlCanvas : MonoBehaviour
{
    //Create a list of image
    public List<Image> images = new List<Image>();
    public PlayerStats myPlayer;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI timer_milliseconds;
    public TextMeshProUGUI timer_seconds;
    public float seconds, milliseconds;
    void Start()
    {           
        seconds = 0;
        milliseconds = 0;
        timer_milliseconds.text = "00";
        timer_seconds.text = "00.";
    }

    // Update is called once per frame
    void Update()
    {
        if(myPlayer.health >= 0){
            for(int i = 0; i < 3 - myPlayer.health; i++){
                images[2-i].color = new Color32(56, 56, 56,255);
            }
            for(int i = 0; i < myPlayer.health; i++){
                images[i].color = new Color32(255, 255, 255,255);
            }
        }
        seconds = (int)(Time.timeSinceLevelLoad % 60f);
        milliseconds = (int)(Time.timeSinceLevelLoad * 1000f) % 1000;

        timer_milliseconds.text = milliseconds.ToString("00");
        timer_seconds.text = seconds.ToString("00.") + ".";
        
        if(myPlayer.enemys_defeated < 10){
            countText.text = "Kills: 00" + myPlayer.enemys_defeated.ToString();
        }
        else if (myPlayer.enemys_defeated < 100){
            countText.text = "Kills: 0" + myPlayer.enemys_defeated.ToString();
        }
        else{
            countText.text = "Kills: " + myPlayer.enemys_defeated.ToString();
        }
    }
}
