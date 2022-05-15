using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBack : MonoBehaviour
{
    private float Pos;

    public float Spead = 15;
    private float Back =-10;

    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.GameOver == false)
        {
            transform.Translate(Vector3.back * Time.deltaTime * Spead);

            if (transform.position.z < Back)
            {
                Destroy(gameObject);
            }
        }
    }

}
