using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

   
    public GameObject Enemy_Bullet = null;
    public float Enemy_BulletSpeed;
    public float Enemy_oneShoting ;// 
    public float Enemy_MoveSpeed;// 
    public int Enemy_Hp ;// Hp

    public Vector3 MovementTarget;//ENEMY 움직임 백터

    bool Enemy_Die = false;//죽었는지 안죽었는지

    public Collider2D Col2d;

    public void Enemy_Hit()
    {
        if (Enemy_Hp <= 0)//만약 Hp가 0이하로 떨어지면
        {
            Enemy_Die = true;//Die는 참
        }
        StartCoroutine(Enemy_Change());
    }
  


    public IEnumerator Pattern_One(float Enemy_oneShoting)
    {
        
    do
        {
            for (int i = 0; i < Enemy_oneShoting; i++)
            {
                GameObject obj;
                obj = (GameObject)Instantiate(Enemy_Bullet, this.transform.position, Quaternion.identity);
                obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(Enemy_BulletSpeed * Mathf.Cos(Mathf.PI * 2 * i / Enemy_oneShoting), Enemy_BulletSpeed * Mathf.Sin(Mathf.PI * i * 2 / Enemy_oneShoting)));
                obj.transform.Rotate(new Vector3(0f, 0f, 360 * i / Enemy_oneShoting - 90));
            }

            //지정해둔 각도의 방향으로 모든 총탄을 날리고, 날아가는 방향으로 방향회전을 해줍니다.

            yield return new WaitForSeconds(1.5f);
        } while ( true);
    }
    public IEnumerator Pattern_Two(float Enemy_oneShoting)
    {
        
        do
        {
            for (int i = 0; i < Enemy_oneShoting; i++)
            {
                GameObject obj;
                obj = (GameObject)Instantiate(Enemy_Bullet, this.transform.position, Quaternion.identity);
                //보스의 위치에 bullet을 생성합니다.
                obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(Enemy_BulletSpeed * Mathf.Cos(Mathf.PI * 2 * i / Enemy_oneShoting), Enemy_BulletSpeed * Mathf.Sin(Mathf.PI * i * 2 / Enemy_oneShoting)));
                obj.transform.Rotate(new Vector3(0f, 0f, 180 * i / Enemy_oneShoting - 90));
                obj.GetComponent<Rigidbody2D>().gravityScale = 0.2f;
            }

           

            yield return new WaitForSeconds(1.5f);
        } while ( true);
    }
    public IEnumerator Pattern_Three(float Enemy_oneShoting)
    {

        do
        {
            for (int i = 0; i < Enemy_oneShoting; i++)
            {
                GameObject obj;
                obj = (GameObject)Instantiate(Enemy_Bullet, this.transform.position, Quaternion.identity);
                obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(Enemy_BulletSpeed * Mathf.Sin(Mathf.PI * 2 * i / Enemy_oneShoting), Enemy_BulletSpeed * Mathf.Cos(Mathf.PI * i * 3 / Enemy_oneShoting)));
                obj.transform.Rotate(new Vector3(0f, 0f, 180 * i / Enemy_oneShoting - 90));
                obj.GetComponent<Rigidbody2D>().gravityScale = 0.1f;
            }



            yield return new WaitForSeconds(0.75f);
        } while (true);
    }

    private IEnumerator Enemy_Change()
    {
        SpriteRenderer sprite = GetComponentInChildren<SpriteRenderer>();

        sprite.color = Color.red;

        yield return new WaitForSeconds(0.1f);

        sprite.color = Color.white;

        yield return null;

    }
    public void Enemy_Move()
    {
        MovementTarget = new Vector3(
               Random.Range(-2.0f, 3.0f),
               Random.Range(3.5f, 4.5f),
               0);

    }
    public void Enemy_MoveCtrl()
    {
        if (Col2d.OverlapPoint(MovementTarget))
        {
            Enemy_Move();
        }
        Vector2 Direction = (MovementTarget - this.transform.position);
        Direction.Normalize();
        this.transform.Translate(Direction * Enemy_MoveSpeed * Time.deltaTime);
    }
    
    public void Enemy_Die_Check(string SCENE)
    {

        
        if (Enemy_Die == true)//총알을 맞았다면
        {
            transform.localScale = new Vector2(transform.localScale.x - 0.01f, transform.localScale.y - 0.01f);//스케일은 작아짐
            transform.Rotate(new Vector3(0, 0, 10));//계속 회전함
            if (transform.localScale.x <= 0)//만약 스케일x값이 0보다 작다면
            {
                Destroy(this.gameObject);//자기 자신 삭제
            }

            GameObject[] obj = GameObject.FindGameObjectsWithTag("BULLETS");

            // Bullet 태그를 가진 오브젝트를 모두 찾아서 배열에 추가
            foreach (GameObject ob in obj)
            {
                Destroy(ob);
                Application.LoadLevel(SCENE);
            }

        }


        if (Enemy_Die == false)//총알을 맞지않았다면
        {
            if (transform.position.y <= -10)//만약 Y값이 -10보다 작거나 같다면
            {
                Destroy(this.gameObject);//자기 자신 삭제
            }

        }
      


    }

}

