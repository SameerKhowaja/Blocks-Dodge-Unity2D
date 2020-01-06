using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public Text Cur_score, High_score;
    float timer;
    public float count = 0;

    void Start()
    {
        High_score.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
        Cur_score.text = count.ToString();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 2f)
        {
            count += 1;
            Cur_score.text = count.ToString();

            if (int.Parse(Cur_score.text) >= PlayerPrefs.GetInt("Highscore", 0))
            {
                PlayerPrefs.SetInt("Highscore", int.Parse(Cur_score.text));
                High_score.text = count.ToString();
            }
            timer = 0;
        }
    }

}
