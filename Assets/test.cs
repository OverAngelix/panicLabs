using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : NetworkBehaviour

{
    // Start is called before the first frame update

    Vector2 fin;

    void Start()
    {
        fin = new Vector2(transform.position.x + 2f, transform.position.y + 2f);
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            move();
        }
    }

    [Command]
    private void move()
    {
        transform.position = fin;
    }
}
