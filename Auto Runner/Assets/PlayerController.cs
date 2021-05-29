using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float vertDirection = Input.GetAxisRaw("Vertical");
        float horDirection = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horDirection * moveSpeed, vertDirection * moveSpeed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
            SceneManager.LoadScene(0);
    }
}
