using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 20f;
    float xPos, maxWidth = 4.8f;
    Vector2 xPosNew;
    public enemyCreateOnRandom enemyScript;
    public GameObject go;
    public AudioSource aud;
    public float slowness = 20f;

    void FixedUpdate()
    {
        xPos = Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime;
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
