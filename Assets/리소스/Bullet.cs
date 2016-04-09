using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{


    bool Hit = false;//총알을 맞았는지
    PlayerCtrl pc = null;//PlayerCtrl스크립트를 담아줌 변수

    BoxCollider2D bc = null;//BoxCollider2D를 넣어줄 변수


    public int Bullet_Kind;

    float i = 0;
    public float BulletSpeed = 4f;
   
    void Awake()
    {
        bc = GetComponent<BoxCollider2D>();//BoxCollider2D를 넣어줌
        pc = GameObject.FindWithTag("PLAYER").GetComponent<PlayerCtrl>();
        Bullet_Kind = Random.Range(0, 2);
    }
    void OnTriggerEnter2D(Collider2D coll)//충돌 체크 함수
    {
        if (coll.gameObject.tag == "PLAYER")
        {
            Hit = true;//총알을 맞음
            pc.hp -= 1;//주인공의 Hp를 하나 깎음 
            pc.PlayerHit();

            Destroy(this.gameObject);
        }
        if (coll.gameObject.tag == "LASER")
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {

    }

    void Update()
    {
        if(Bullet_Kind == 1)
        {
            SpriteRenderer sprite = GetComponentInChildren<SpriteRenderer>();

            sprite.color = Color.red;
        }

    }


    void OnBecameInvisible() //화면에서 탄막이 나가면 삭제시킨다.
    {

        Destroy(this.gameObject);


    }

}