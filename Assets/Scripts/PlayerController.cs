using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject spawn;
    public GameObject Track;
    private float HorizontalInput;
    public float Spead = 0.5f;
    private int Pos = 2;
    public Vector3 spawnPosition;
    public Vector3 spawnTrackPosition;
    public bool GameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spavnTrack", 0.01f, 0.01f);
        

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -Pos)
        {
            transform.position = new Vector3( -Pos, transform.position.y, transform.position.z );
        } 
        if (transform.position.x > Pos)
        {
            transform.position = new Vector3(Pos, transform.position.y, transform.position.z);
        }
        if (GameOver == false)
        {
            HorizontalInput = Input.GetAxis("Horizontal");

            transform.Translate(Vector3.right * Time.deltaTime * -HorizontalInput * Spead);
            /*if (transform.rotation.y != 180)
            {
                transform.Rotate(0,180,0);
            }*/
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameOver = true;
        } 
        else if(collision.gameObject.CompareTag("CUBE"))
        {
            spawnPosition = transform.position;
            transform.Translate(Vector3.up * 1);
            //Destroy(gameObject);
            
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        spawnPosition = transform.position;
        transform.Translate(Vector3.up * 1.2f);
        Instantiate(spawn, spawnPosition, spawn.transform.rotation);
    }

    void spavnTrack()
    {
        if (GameOver == false)
        {
            /*if (transform.position.y < 0.15f)
            {*/
                float PositionX = transform.position.x;
                spawnTrackPosition = new Vector3(PositionX, 0.052f, -1.6f);
                Instantiate(Track, spawnTrackPosition, Track.transform.rotation);
            //}
        }
    }

}
