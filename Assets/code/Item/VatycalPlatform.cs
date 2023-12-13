using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VatycalPlatform : MonoBehaviour
{
    private PlatformEffector2D effector;
    private float waiTime;
    
    // Start is called before the first frame update
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            waiTime = 0.5f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (waiTime <= 0)
            {
                effector.rotationalOffset = 180f;
                waiTime = 0.5f;
            }
            else
            {
                waiTime -= Time.deltaTime;
            }
        }

        if (Input.GetKeyDown("space"))
        {
            effector.rotationalOffset = 0f;
        }
    }
}
