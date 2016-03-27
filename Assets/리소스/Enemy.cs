using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

   
    public GameObject Enemy_Bullet = null;
    public float Enemy_Speed  ;
    public float Enemy_oneShoting ;// 
    public int Enemy_Hp ;// Hp


    bool Enemy_Die = false;//죽었는지 안죽었는지


    public void Enemy_Hit()
    {
        if (Enemy_Hp <= 0)//만약 Hp가 0이하로 떨어지면
        {
            Enemy_Die = true;//Die는 참
        }
    }


    public IEnumerator Pattern_One()
    {
    do
        {
            for (int i = 0; i < Enemy_oneShoting; i++)
            {
                GameObject obj;
                obj = (GameObject)Instantiate(Enemy_Bullet, this.transform.position, Quaternion.identity);
                //보스의 위치에 bullet을 생성합니다.
                obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(Enemy_Speed * Mathf.Sin(Mathf.PI * 2 * i / Enemy_oneShoting), Enemy_Speed * Mathf.Cos(Mathf.PI * i * 2 / Enemy_oneShoting)));
                obj.transform.Rotate(new Vector3(0f, 0f, 360 * i / Enemy_oneShoting - 90));
            }

            //지정해둔 각도의 방향으로 모든 총탄을 날리고, 날아가는 방향으로 방향회전을 해줍니다.

            yield return new WaitForSeconds(1.5f);
        } while (true);
    }



    public void Enemy_Die_Check()
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

            // Bullet_E 태그를 가진 오브젝트를 모두 찾아서 배열에 추가
            foreach (GameObject ob in obj)
            {
                Destroy(ob);
            }

        }


        if (Enemy_Die == false)//총알을 맞지않았다면
        {
            //transform.Translate(Vector2.down * Time.deltaTime * 0.5f);//밑으로 계속 이동
            if (transform.position.y <= -10)//만약 Y값이 -10보다 작거나 같다면
            {
                Destroy(this.gameObject);//자기 자신 삭제
            }

        }


    }
}

  
       

