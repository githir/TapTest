using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    public GameObject[] ballTags;
    public int[,] scoreMap;
    public int[,] scoreMap_prev;

    private GameObject[,] goalAreaObject;
    private Renderer[,] goalAreaObjectRenderer;
    private Color[,] goalAreaObjectColor;

    // Start is called before the first frame update
    void Start()
    {
        if (ballTags == null)
        {
            ballTags = GameObject.FindGameObjectsWithTag("BallTag");
        }
        scoreMap = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        scoreMap_prev = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };

        goalAreaObject = new GameObject[3, 3];
        goalAreaObjectRenderer = new Renderer[3, 3];
//        goalAreaObjectColor = new Color[3, 3];

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                string objectName = "GoalSquarePrefab " + j + "-" + i;
                Debug.Log("init gameObject:" + i +","+ j + "," + objectName);
                goalAreaObject[i, j] = GameObject.Find(objectName);
                goalAreaObjectRenderer[i, j] = goalAreaObject[i, j].GetComponent<Renderer>();
//                goalAreaObjectColor[i, j] = goalAreaObject[i, j].GetComponent<Renderer>().material.color;
            }
        }
        /* check
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; i < 3; i++)
            {
                goalAreaObject[i, j].GetComponent<Renderer>().material.color = Color.blue;
            }
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        ballTags = GameObject.FindGameObjectsWithTag("BallTag");
        //Debug.Log("# of ballTags" + ballTags.Length.ToString());

        int count = 0;
        scoreMap = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        foreach (GameObject ballTag in ballTags)
        {
            count++;
            //   Debug.Log("" + count + " " + ballTag.GetComponent<Transform>().position + " " + ballTag.GetComponent<BallController>().myHomeObject.name);
            //   string objectName = ballTag.GetComponent<BallController>().myHomeObject.name;

            if(ballTag.GetComponent<BallController>().myHomeObject == null)
            {
            //    Debug.Log("where is myHome?");
                continue;
            }
            string objectName = ballTag.GetComponent<BallController>().myHomeObject.name;

         //   Debug.Log("myHomeObject.name " + objectName);

            if (objectName.Contains("NoGoalArea"))
            {
                continue;
            }

            if (! objectName.Contains("Goal"))
            {
                continue;
            }

            string[] objectName_ID = ballTag.GetComponent<BallController>().myHomeObject.name.Split(' ')[1].Split('-');
            int col = int.Parse(objectName_ID[0]);
            int row = int.Parse(objectName_ID[1]);
          //  Debug.Log(count + "> col:" + col + ", row:" + row);

            scoreMap[row, col] += 1;

            //for debug
            int[,] len = scoreMap;
            for (int i = 0; i < len.GetLength(0); i++)
            {
                string str = "";
                for (int j = 0; j < len.GetLength(1); j++)
                {
                    str = str + len[i, j] + " ";
                }
         //        Debug.Log(str);
            }
        }

        for (int i = 0; i < 3; i++)
        {
            string str = "";
            string str_bool = "";
            for (int j = 0; j < 3; j++)
            {
                str = str + scoreMap[i, j] + " ";
                /*
                if (scoreMap[i, j] == scoreMap_prev[i,j])
                {
                    str_bool = str_bool + "T ";
                }
                else
                {
                    str_bool = str_bool + "F ";
                }
                */

                if (scoreMap[i, j] == 0)
                {
                    //      goalAreaObjectRenderer[i, j].material.color = Color.green;
                    goalAreaObjectRenderer[i, j].material.color = new Color(7.0f / 255, 65.0f / 255, 10.0f / 255, 1);
                    // goalAreaObjectRenderer[i, j].material.color = Color.blue;
                    //  goalAreaObjectColor[i, j] = Color.blue;
                }
                else
                {
                    goalAreaObjectRenderer[i, j].material.color = Color.red;
                  //  goalAreaObjectColor[i, j] = Color.red;
                }
             //   Debug.Log("search:" + i + "," + j + " > " + scoreMap_prev[i, j] + " to " + scoreMap[i, j]);
                 //                   scoreMap_prev = scoreMap;


            }
  //          Debug.Log(str + ", no change :" + str_bool);
            Debug.Log(str);
        }
        Debug.Log("scoreTotal = " + GetScore(scoreMap));
    }

    //スリーアイズ的なスコア集計   https://japan-3eyes.net/
    int GetScore(int[,] x)
    {
        int scoreTotal;
        int lineCount = 0;

        //行
        int Col_0 = x[0,0] * x[1,0] * x[2,0];
        if (Col_0 > 0) lineCount++;
        int Col_1 = x[0,1] * x[1,1] * x[2,1];
        if (Col_1 > 0) lineCount++;
        int Col_2 = x[0,2] * x[1,2] * x[2,2];
        if (Col_2 > 0) lineCount++;

        //列
        int Row_0 = x[0,0] * x[0,1] * x[0,2];
        if (Row_0 > 0) lineCount++;
        int Row_1 = x[1,0] * x[1,1] * x[1,2];
        if (Row_1 > 0) lineCount++;
        int Row_2 = x[2,0] * x[2,1] * x[2,2];
        if (Row_2 > 0) lineCount++;

        //対角
        int Diag_0 = x[0,0] * x[1,1] * x[2,2];
        if (Diag_0 > 0) lineCount++;
        int Diag_1 = x[0,2] * x[1,1] * x[2,0];
        if (Diag_1 > 0) lineCount++;

        //パーフェクト？
        if (lineCount > 1)
        {
            scoreTotal = 5;
        }
        else
        {
            scoreTotal = Col_0 + Col_1 + Col_2 + Row_0 + Row_1 + Row_2 + Diag_0 + Diag_1;
        }

        return (scoreTotal);
    }
}
