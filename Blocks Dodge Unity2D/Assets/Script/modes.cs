using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class modes : MonoBehaviour
{
    public score sc;
    public enemyCreateOnRandom ecr;
    public playerMove pm;
    public Text start, highscore;
    public AudioSource aud;

    private void Start()
    {
        highscore.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if (Input.GetKey("s"))
        {
            sc.enabled = ecr.enabled = pm.enabled = true;
            start.enabled = false;
            aud.enabled = true;
        }

        if (Input.GetKey("r"))
        {
            PlayerPrefs.DeleteKey("Highscore");
            highscore.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
        }

    }
}
