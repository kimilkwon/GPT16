using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {


    bool Hit = false;//총알을 맞았는지
    PlayerCtrl pc = null;//PlayerCtrl스크립트를 담아줌 변수
    BoxCollider2D bc = null;//BoxCollider2D를 넣어줄 변수
    public GameObject Boom = null;

    public int Bullet_Kind;

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

            // Instantiate(Boom, this.transform.position, Quaternion.identity);

              Destroy(this.gameObject);
        }
    }
    void Start()
    {
    }

    void Update()
    {
        // DeletObjectF();
        Destroy(this.gameObject,4f);

    }




    void DeletObjectF()
    {
        if (transform.position.y <= -7f)
        {
            Destroy(this.gameObject);
        }
        if (transform.position.y >= 6f)
        {
            Destroy(this.gameObject);
        }
        if (transform.position.x <= -3f)
        {
            Destroy(this.gameObject);
        }
        if (transform.position.x >= 3f)
        {
            Destroy(this.gameObject);
        }
    }
}
