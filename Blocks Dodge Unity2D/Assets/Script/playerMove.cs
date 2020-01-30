using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    float xPos, maxWidth = 2.4f;
    Vector2 xPosNew;
    float XPosInput;
    public enemyCreateOnRandom enemyScript;
    public GameObject go;
    public AudioSource aud;
    public float slowness = 20f;

    Touch touch;
    Vector3 touchPos;

    private void Update()
    {
        XPosInput = Input.GetAxis("Horizontal");

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            if (touchPos.x > 0)
                XPosInput = 1;
            else if (touchPos.x < 0)
                XPosInput = -1;
            else
                XPosInput = 0;
        }
    }

    void FixedUpdate()
    {
        xPos = XPosInput * speed * Time.fixedDeltaTime;
        xPosNew = rb.position + Vector2.right * xPos;
        xPosNew.x = Mathf.Clamp(xPosNew.x, -maxWidth, maxWidth);
        rb.MovePosition(xPosNew);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "enemy")
        {
            aud.enabled = true;
            StartCoroutine(resart());
        }    
    }

    IEnumerator resart()
    {
        Time.timeScale = 1f / slowness;
        Time.fixedDeltaTime = Time.fixedDeltaTime / slowness;
        yield return new WaitForSeconds(1f / slowness);
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime * slowness;

        LoadScene();
    }

    void LoadScene()
    {
        SceneManager.LoadScene("lvl01");
    }

}
