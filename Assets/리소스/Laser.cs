using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour
{
    float LaserSpeed = 12f;
 
    Enemy EM = null;
    BoxCollider2D bc = null;
    private ScoreCtrl SC = null;

    void Awake()
    {
        bc = GetComponent<BoxCollider2D>();//BoxCollider2D를 넣어줌
        EM = GameObject.FindWithTag("ENEMY").GetComponent<Enemy>(); 
        SC = GameObject.Find("Center").GetComponent<ScoreCtrl>();
    }
    void OnTriggerEnter2D(Collider2D coll)//충돌 체크 함수
    {
        if (coll.gameObject.tag == "ENEMY")
        {
         
            EM.Enemy_Hp -= 1;// Hp를 하나 깎음 
            EM.Enemy_Hit();
            Destroy(this.gameObject);
        }

        if (coll.gameObject.tag == "BULLETS")
        {
             
            Destroy(this.gameObject);
            SC.ScoreUp(10);
           
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
