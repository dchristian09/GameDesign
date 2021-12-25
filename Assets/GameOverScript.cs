using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public GameObject P1WINUI;
    public GameObject P2WINUI;
    public GameObject NOBODYWINUI;
    // Start is called before the first frame update
    public void Setup(int player)
    {
        gameObject.SetActive(true);
        if (player == 1)
        {
            P1WINUI.SetActive(true);
        }
        else if (player == 2)
        {
            P2WINUI.SetActive(true);
        }
        else if (player == 3)
        {
            NOBODYWINUI.SetActive(true);
        }
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void ExitButton()
    {

    }



}
