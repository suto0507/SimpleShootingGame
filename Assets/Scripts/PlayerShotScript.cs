using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShotScript : MonoBehaviour
{

    public float speed = 10f;
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
        //敵機に当たったならダメージを与える
        if(collision.gameObject.CompareTag("Enemy")){
            EnemyScript es = collision.gameObject.GetComponent<EnemyScript>();
            es.Damaged();
        }
        if(collision.gameObject.CompareTag("wall")){
            Destroy(gameObject);
        }
    }
}
