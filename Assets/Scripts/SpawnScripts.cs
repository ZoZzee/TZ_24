using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScripts : MonoBehaviour
{
    public GameObject[] spawnScript;

    private Vector3 spawnPosition;
    public int SpawnSimpl=0;

    private PlayerController PlayerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spavnPost", 0.5f, 0.5f);
        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void spavnPost()
    {
        if (PlayerControllerScript.GameOver == false)
        {

            if (SpawnSimpl < 3)
            {
                spawnPosition = new Vector3(Random.Range(-2,3), 0.60f, 75);
                Instantiate(spawnScript[0], spawnPosition, spawnScript[0].transform.rotation);
                SpawnSimpl++;
            }
            else if(SpawnSimpl == 3)
            {
                for(int x = -2; x<=2;x++ )
                {
                    //spawnPosition = new Vector3(x, 0.60f, 60);
                    for (int y = 0; y <= Random.Range(1, 4); y++)
                    {
                        spawnPosition = new Vector3(x, y + 0.05f, 75);
                        Instantiate(spawnScript[1], spawnPosition, spawnScript[1].transform.rotation);
                    }
                }
                SpawnSimpl = 0;
            }
            
        }

    }
}
