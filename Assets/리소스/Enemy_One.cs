using UnityEngine;
using System.Collections;

public class Enemy_One : Enemy {



    float PatternDeltaTime = 0.0f;
    float EnemyPatternTime = 10.0f;


    // Use this for initialization
    void Start () {
        Enemy_BulletSpeed = 50f;
        Enemy_Hp =10;
        Enemy_MoveSpeed = 0.5f;
        Enemy_Move();
        StartCoroutine("Pattern_Three",10f);
       
    }
	
	// Update is called once per frame
	void Update () {
        Enemy_Die_Check("SCENE_TWO");
        

        PatternDeltaTime += Time.deltaTime;
            if (PatternDeltaTime > EnemyPatternTime)
            {
            PatternDeltaTime = 0.0f;
            this.StartCoroutine("Pattern_Two",15f);
            }
        Enemy_MoveCtrl();

    }

 
}
