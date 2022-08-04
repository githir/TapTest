using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillerController : MonoBehaviour
{
    private float timeToDestoroy;　　//倒れたあとしばらく残すためのタイマー（これから実装）

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //資料 【Unity】キャラクターが「倒れたか」をスマートに判定
        //https://www.zkn0hr.com/unity-check-toppled/

        float angle = Vector3.Angle(Vector3.up, transform.up);
        if (angle > 90.0f)
        {
            Destroy(this.gameObject);
        }
    }
}