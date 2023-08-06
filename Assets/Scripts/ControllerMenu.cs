using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ControllerMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public Button StartGame;
    public Button ExitGame;
    public TextMeshProUGUI StartText;
    public TextMeshProUGUI ExitText;
    void Start()
    {
        StartGame.onClick.AddListener(() => {
            Time.timeScale = 1;
            SceneManager.LoadScene("Game");
        });
        ExitGame.onClick.AddListener(() => {
            Application.Quit();
        });
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
