using UnityEngine;
using System.Collections;

public class Enemy_One : Enemy {



    float PatternDeltaTime = 0.0f;
    float EnemyPatternTime = 10.0f;


    // Use this for initialization
    void Start () {
        Enemy_Speed = 50f;
        Enemy_Hp =1;
     

        StartCoroutine("Pattern_One",15f);
       
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
 

    }

 
}
