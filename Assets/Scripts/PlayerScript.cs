using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public GameObject ShotPrefab;

    public float speed = 10f;
    Rigidbody myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        myRigidbody.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, 0f, 0f);

        //進行方向と同じ向きにする
        Vector2 lscale = gameObject.transform.localScale;
        if ((lscale.x > 0 &&  myRigidbody.velocity.x < 0)
            || (lscale.x < 0 &&  myRigidbody.velocity.x > 0))
        {
            lscale.x *= -1;
            gameObject.transform.localScale = lscale;
        }

        //弾の発射
        if (Input.GetKeyDown(KeyCode.Space)) {
            Vector3 pos = gameObject.transform.position;
            Instantiate(ShotPrefab, pos, Quaternion.identity);
        }
    }

    //ダメージを受けると消滅する
    public void Damaged(){
        Destroy(gameObject);
    }
}
