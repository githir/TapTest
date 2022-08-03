using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    GameObject g;
    Rigidbody rb;
    float born;
    public Vector3 force = new Vector3(0.0f, 0.0f, 1.0f);    // —Í‚ğİ’è


    // Start is called before the first frame update
    void Start()
    {
        //        g = GameObject.Find("BallPrefab");
        //        rb = this.GetComponent<Rigidbody>();  // rigidbody‚ğæ“¾
        //        rb.AddForce(force, ForceMode.Impulse);  // —Í‚ğ‰Á‚¦‚é
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
