using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterScript : MonoBehaviour
{

    public GameObject shotPrefab;
    public float speed;
    protected Rigidbody myRigidbody;

    // Start is called before the first frame update
    protected void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    protected void Update()
    {
        //進行方向と同じ向きにする
        Vector2 lscale = gameObject.transform.localScale;
        if ((lscale.x > 0 && myRigidbody.velocity.x < 0)
            || (lscale.x < 0 && myRigidbody.velocity.x > 0))
        {
            lscale.x *= -1;
            gameObject.transform.localScale = lscale;
        }
    }

    //ダメージを受けると消滅する
    public void Damaged()
    {
        Destroy(gameObject);
    }
}
