using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject ShotPrefab;
    public float speed = 10f;
    Rigidbody myRigidbody;

    float direction = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        StartCoroutine("Attack");         
    }

    // Update is called once per frame
    void Update()
    {
        myRigidbody.velocity = new Vector3(direction * speed, 0f, 0f);

        //進行方向と同じ向きにする
        Vector2 lscale = gameObject.transform.localScale;
        if ((lscale.x < 0 && myRigidbody.velocity.x < 0)
            || (lscale.x > 0 && myRigidbody.velocity.x > 0))
        {
            lscale.x *= -1;
            gameObject.transform.localScale = lscale;
        }

    }

    //壁にぶつかったら方向転換する
    void OnCollisionEnter(Collision collision)
    {  
        Debug.Log(collision.gameObject.tag);
        if(collision.gameObject.CompareTag("wall")){
            direction = direction * -1.0f;
        }
    }

    //1秒ごとに弾を発射する
    private IEnumerator Attack(){
        while(true){
            Vector3 pos = gameObject.transform.position;
            Instantiate(ShotPrefab, pos, Quaternion.identity);
            yield return new WaitForSeconds(2f);
        }
    }

    //ダメージを受けると消滅する
    public void Damaged(){
        Destroy(gameObject);
    }
}
