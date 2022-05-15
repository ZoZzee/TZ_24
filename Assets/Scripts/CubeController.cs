using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public GameObject player;
    public GameObject spawn;
    public GameObject Track;

    public Vector3 transformPos;
    private Vector3 spawnPosition;
    private Vector3 spawnTrackPosition;
    public bool gameOver = false;
    private float HorizontalInput;
    private float Back = -10;
    private float Pos = 2;


    //private MovementBack MovementBackInt;
    private PlayerController playerControllerScript;


    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("spavnTrack", 0.01f, 0.01f);
        //MovementBackInt = GameObject.Find("CubeWall").GetComponent<MovementBack>();
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
            
            if (transform.position.x < -Pos)
            {
                transform.position = new Vector3(-Pos, transform.position.y, transform.position.z);
            }
            if (transform.position.x > Pos)
            {
                transform.position = new Vector3(Pos, transform.position.y, transform.position.z);
            }
        if (playerControllerScript.GameOver == false)
        {
            if (gameOver == true)
            {
                transform.Translate(Vector3.back * Time.deltaTime * 15);
            }
            if (gameOver == false)
            {
                HorizontalInput = Input.GetAxis("Horizontal");

                transform.Translate(Vector3.right * Time.deltaTime * HorizontalInput * 0.5f);
            }


        }
        if (transform.position.z < Back)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        spawnPosition = transform.position;
        playerControllerScript.transform.Translate(Vector3.up * 1.2f);
        
        transform.Translate(Vector3.up * 1.5f);
        
        Instantiate(spawn, spawnPosition, spawn.transform.rotation);
    }
    /*void spavnTrack()
    {
        if (playerControllerScript.GameOver == false)
        {
            if (gameOver == false)
            {
                if (transform.position.y < 0.15f)
                {
                    float PositionX = transform.position.x;
                    spawnTrackPosition = new Vector3(PositionX, 0.052f, -1.6f);
                    Instantiate(Track, spawnTrackPosition, Track.transform.rotation);
                }
            }
        }
    }*/

}
