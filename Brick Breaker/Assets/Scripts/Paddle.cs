using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed;
    private float leftBound = -5.6f;
    private float rightBound = 5.6f;
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameOver)
        {
            return; 
        }

        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * horizontal * Time.deltaTime * speed);

        if (transform.position.x < leftBound)
            transform.position = new Vector3(leftBound, transform.position.y, 1);
        if (transform.position.x > rightBound)
            transform.position = new Vector3(rightBound, transform.position.y, 1);
    }
}
