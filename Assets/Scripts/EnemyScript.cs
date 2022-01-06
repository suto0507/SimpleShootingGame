using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : FighterScript
{

    float direction = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        StartCoroutine("Attack");         
    }

    // Update is called once per frame
    void Update()
    {
        myRigidbody.velocity = new Vector3(direction * speed, 0f, 0f);

        base.Update();
    }

    //壁にぶつかったら方向転換する
    void OnCollisionEnter(Collision collision)
    {  
        Debug.Log(collision.gameObject.tag);
        if(collision.gameObject.CompareTag("Wall"))
        {
            direction = direction * -1.0f;
        }
    }

    //1秒ごとに弾を発射する
    private IEnumerator Attack()
    {
        while(true)
        {
            Vector3 pos = gameObject.transform.position;
            Instantiate(shotPrefab, pos, Quaternion.identity);
            yield return new WaitForSeconds(2f);
        }
    }
}
