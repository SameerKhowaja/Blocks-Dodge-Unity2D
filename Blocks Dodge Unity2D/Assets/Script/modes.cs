using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class modes : MonoBehaviour
{
    public score sc;
    public enemyCreateOnRandom ecr;
    public playerMove pm;
    public Text highscore;
    public AudioSource aud;

    public Canvas ButtonCanvas;

    private void Start()
    {
        highscore.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            PlayerPrefs.DeleteKey("Highscore");
            highscore.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
        }

    }


    public void ExitBTN()
    {
        Application.Quit();
    }

    public void StartBTN()
    {
        ButtonCanvas.enabled = false;

        sc.enabled = ecr.enabled = pm.enabled = true;
        aud.enabled = true;
    }

}
