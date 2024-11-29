using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class movement : MonoBehaviour
{
    public GameObject Animation;
    public Rigidbody2D rb;
    public static float speed = 160f;
    public static float maxSpeed = 5f;

    void Start()
    {
        
    }

    void Update()
    {
        faceMouse();
        if (myPlayer.speedOn == true)
        {
            speed = 240f;
            maxSpeed = 6f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "levelChange1")
        {
            var lvl2 = Animation.GetComponent<levelChanger>();
            lvl2.fadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (collision.gameObject.tag == "Menu")
        {
            var lvl2 = Animation.GetComponent<levelChanger>();
            lvl2.fadeToLevel(1);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(x, y);

        rb.AddForce(movement * Time.deltaTime * speed);
        //rb.MovePosition(new Vector2((transform.position.x + velocity.x * Time.deltaTime), (transform.position.y + velocity.y * Time.deltaTime)));
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        }
    }

    void faceMouse()
    {
        Vector3 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
