using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    public string opponentTag;
    public float speed;
    Rigidbody myRigidbody;

    // Start is called before the first frame update
    protected void Start()
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
        if(collision.gameObject.CompareTag(opponentTag))
        {
            FighterScript fs = collision.gameObject.GetComponent<FighterScript>();
            fs.Damaged();
        }
        if(collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
