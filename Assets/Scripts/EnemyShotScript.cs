using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotScript : MonoBehaviour
{
    public float speed = -10f;
    Rigidbody myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        myRigidbody.velocity = new Vector3(0f, speed, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //なにかとぶつかったとき弾は消える
    void OnCollisionEnter(Collision collision)
    {
        //自機に当たったならダメージを与える
        if(collision.gameObject.CompareTag("Player")){
            PlayerScript ps = collision.gameObject.GetComponent<PlayerScript>();
            ps.Damaged();
        }
        if(collision.gameObject.CompareTag("wall")){
            Destroy(gameObject);
        }
    }
}
