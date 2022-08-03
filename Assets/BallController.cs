using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    GameObject g;
    Rigidbody rb;
    float born;
    public Vector3 force = new Vector3(0.0f, 0.0f, 1.0f);    // 力を設定


    // Start is called before the first frame update
    void Start()
    {
        //        g = GameObject.Find("BallPrefab");
        //        rb = this.GetComponent<Rigidbody>();  // rigidbodyを取得
        //        rb.AddForce(force, ForceMode.Impulse);  // 力を加える
        g = GameObject.Find("GameObject");
        rb = GetComponent<Rigidbody>();
        born = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - born > 3.0f)
        {
            var velocity = rb.velocity;
            if (velocity.sqrMagnitude < 0.01f) {
                Debug.Log("STOP");
                Destroy(this.gameObject);
                g.GetComponent<TapTest>().numBalls -= 1;
            }
            Debug.Log(velocity.sqrMagnitude);
        }
    }
}
