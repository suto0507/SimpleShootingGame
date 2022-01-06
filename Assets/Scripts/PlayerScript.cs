using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : FighterScript
{

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        myRigidbody.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, 0f, 0f);

        base.Update();

        //弾の発射
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Vector3 pos = gameObject.transform.position;
            Instantiate(shotPrefab, pos, Quaternion.identity);
        }
    }
}
