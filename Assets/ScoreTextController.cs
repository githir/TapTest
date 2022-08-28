using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextController : MonoBehaviour
{
    //スコアを表示するテキスト
    private GameObject scoreText;
    //得点
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        //シーン中のscoreTextオブジェクトを取得
        this.scoreText = GameObject.Find("ScoreText");
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.GetComponent<Text>().text = " "+score;
    }
}
