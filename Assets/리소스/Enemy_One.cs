using UnityEngine;
using System.Collections;

public class Enemy_One : Enemy {


  

 


    // Use this for initialization
    void Start () {
        Enemy_Speed = 20f;
        Enemy_oneShoting = 20f;
        Enemy_Hp = 2;
        StartCoroutine(Pattern_One());
    }
	
	// Update is called once per frame
	void Update () {
        Enemy_Die_Check();
        
    }
}
