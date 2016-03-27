using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour
{
    float LaserSpeed = 12f;
 
    Enemy EM = null;//PlayerCtrl스크립트를 담아줌 변수
    BoxCollider2D bc = null;//BoxCollider2D를 넣어줄 변수
    // Use this for initialization
   
    void Awake()
    {
        bc = GetComponent<BoxCollider2D>();//BoxCollider2D를 넣어줌
        EM = GameObject.FindWithTag("ENEMY").GetComponent<Enemy>();
        
    }
    void OnTriggerEnter2D(Collider2D coll)//충돌 체크 함수
    {
        if (coll.gameObject.tag == "ENEMY")
        {
         
            EM.Enemy_Hp -= 1;// Hp를 하나 깎음 
            EM.Enemy_Hit();
        }
    }
    void Start()
    {
        Destroy(this.gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * LaserSpeed * Time.deltaTime);
    }

}
