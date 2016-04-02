using UnityEngine;
using System.Collections;

public class Enemy_One : Enemy {


  

 


    // Use this for initialization
    void Start () {
        Enemy_Speed = 50f;
        
        Enemy_Hp =300;
        StartCoroutine(Pattern_Two(15f));
    }
	
	// Update is called once per frame
	void Update () {
        Enemy_Die_Check();
        
    }
}
