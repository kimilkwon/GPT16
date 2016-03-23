using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {


    bool Hit = false;//총알을 맞았는지
    PlayerCtrl pc = null;//PlayerCtrl스크립트를 담아줌 변수
    BoxCollider2D bc = null;//BoxCollider2D를 넣어줄 변수
    float oneShoting = 10f;
    float speed = 1f;

    float i = 0;
    public float BulletSpeed = 4f;
    Time StartTime = null;
    void Awake()
    {
        bc = GetComponent<BoxCollider2D>();//BoxCollider2D를 넣어줌
        pc = GameObject.FindWithTag("PLAYER").GetComponent<PlayerCtrl>();
        //태그가 Player인 객체를 찾아 PlayerCtrl컴포넌트를 넣어줌
    }
    void OnTriggerEnter2D(Collider2D coll)//충돌 체크 함수
    {
        if (coll.gameObject.tag == "PLAYER")
        {
            Hit = true;//총알을 맞음
            pc.hp -= 1;//주인공의 Hp를 하나 깎음 
            pc.PlayerHit();
        }
    }
    void Start()
    {
    }

    void Update()
    {
       
        



        if (transform.position.y <= -7f)//만약 포지션 x값이 0보다 작다면
        {
            Destroy(this.gameObject);//자기 자신 삭제
        }
    }
}
