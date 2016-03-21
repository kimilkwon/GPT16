using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    bool Hit = false;//총알을 맞았는지
    BoxCollider2D bc = null;//BoxCollider2D를 넣어줄 변수
    PlayerCtrl pc = null;//Player스크립트를 담아줌 변수
    public GameObject EnemyLaser = null;


    float StartTime = 0f;
    void Awake()
    {
        bc = GetComponent<BoxCollider2D>();//BoxCollider2D를 넣어줌
        pc = GameObject.FindWithTag("PLAYER").GetComponent<PlayerCtrl>();
        //태그가 Player인 객체를 찾아 PlayerMove 넣어줌
    }
    void OnTriggerEnter2D(Collider2D coll)//충돌 체크 함수
    {
        if (coll.gameObject.tag == "PLASER")//만약 충돌한 태그가 LASER라면
        {
            Destroy(coll.gameObject);//총알 삭제
            Hit = true;//총알을 맞음
        }
        else if (coll.gameObject.tag == "PLAYER")
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
        
        if (Hit == false)//총알을 맞지않았다면
        {
            StartTime += Time.deltaTime;
            transform.Translate(Vector2.down * Time.deltaTime * 0.5f);//밑으로 계속 이동
            if (transform.position.y <= -10)//만약 Y값이 -10보다 작거나 같다면
            {
                Destroy(this.gameObject);//자기 자신 삭제
            }

            if (StartTime > 0.5f)
            {
                Instantiate(EnemyLaser, this.transform.position, Quaternion.identity);

                StartTime = 0f;
            }

        }

        if (Hit == true)//총알을 맞았다면
        {
           

            bc.enabled = false;//BoxCollider2D를 꺼줌~!
            transform.localScale = new Vector2(transform.localScale.x - 0.01f, transform.localScale.y - 0.01f);//스케일은 작아짐
            transform.Rotate(new Vector3(0, 0, 10));//계속 회전함
            if (transform.localScale.x <= 0)//만약 스케일x값이 0보다 작다면
            {
                Destroy(this.gameObject);//자기 자신 삭제
            }

        }

    }
}
