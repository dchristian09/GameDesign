using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject P1LOSEUI;
    public GameObject P2LOSEUI;
    public GameObject GreenlightUI;
    public GameObject RedlightUI;
    public GameOverScript GameOverScript;
    private int player1=0;
    private int player2=0;
    private int winner=0;
    private bool p1lose = false;
    private bool p2lose = false;
    public AudioSource audio;
    public int target = 5;
    //green light = true red light = false
    private bool greenlight = true;
    private float playtime = 5.0f;
    void Start()
    {
        Time.timeScale = 1;
        player1 = 0;
        player2 = 0;
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (greenlight == true)
        {
            GreenlightUI.SetActive(true);
            RedlightUI.SetActive(false);
        }
        else if (greenlight == false)
        {
            audio.Play();
            GreenlightUI.SetActive(false);
            RedlightUI.SetActive(true);
        }
        //greenlight boleh jalan
        if (Input.GetKeyDown(KeyCode.Space) && p1lose == false && greenlight == true && winner == 0)
        {
            player1 = player1 + 1;
        }
        if (Input.GetKeyDown(KeyCode.KeypadEnter) && p2lose == false && greenlight == true && winner == 0)
        {
            player2 = player2 + 1;
        }

        //cek udah menang belum (target tap)
        if (target == player1)
        {
            stop();
            winner = 1;
            GameOverScript.Setup(winner);
        }
        else if (target == player2)
        {
            stop();
            winner = 2;
            GameOverScript.Setup(winner);
        }
        else if (p1lose == true && p2lose == true)
        {
            stop();
            winner = 3;
            GameOverScript.Setup(winner);
        }

        //timer dari greenlight kapan harus ke redlight
        if (playtime <= 0 && greenlight == true)
        {
            playtime = 5.0f;
            greenlight = false;
        }
        else if (playtime > 0 && greenlight == true)
        {
            playtime -= Time.deltaTime;
        }

        //red light
        //kalau dipencet player kalah
        if (Input.GetKeyDown(KeyCode.Space) && greenlight == false)
        {
            P1LOSEUI.SetActive(true);
            p1lose = true;
        }
        else if (Input.GetKeyDown(KeyCode.KeypadEnter) && greenlight == false)
        {
            P2LOSEUI.SetActive(true);
            p2lose = true;
        }

        //timer dari redlight menuju greenlight
        if (playtime <= 0 && greenlight == false && winner == 0)
        {
            playtime = 5.0f;
            greenlight = true;
        }
        else if (playtime > 0 && greenlight == false && winner==0)
        {
            playtime -= Time.deltaTime;
        }
    }

    public void stop()
    {
        audio.Stop();
        P1LOSEUI.SetActive(false);
        P2LOSEUI.SetActive(false);
        Time.timeScale = 0;
    }
}
