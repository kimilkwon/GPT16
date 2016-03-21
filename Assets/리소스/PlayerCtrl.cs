using UnityEngine;
using System.Collections;

public class PlayerCtrl : MonoBehaviour {

    float Player_Speed = 2.0f;
    public GameObject laser = null;
    public int hp = 3;//플레이어 Hp
    bool Die = false;//죽었는지 안죽었는지


    public void PlayerHit()//EnemyCtrl스크립트에서 충돌시 불러줄꺼임
    {
        if (hp <= 0)//만약 Hp가 0이하로 떨어지면
        {
            Die = true;//Die는 참
        }
    }

    void Update()
    {
        if (Die == true)//Die가 참이라면
        {
            transform.localScale = new Vector2(transform.localScale.x - 0.01f, transform.localScale.y - 0.01f);//스케일은 작아짐
            transform.Rotate(new Vector3(0, 0, 10));//계속 회전함
            if (transform.localScale.x <= 0)//만약 스케일x값이 0보다 작다면
            {
                Destroy(this.gameObject);//자기 자신 삭제
            }
        }
        else if (Die == false)
        {
            if (Input.GetKey(KeyCode.LeftArrow))//왼쪽을 눌렀다면
            {
                transform.Translate(Vector2.left * Player_Speed * Time.deltaTime);//왼쪽으로 speed만큼 이동
            }
            if (Input.GetKey(KeyCode.RightArrow))//오른쪽을 눌렀다면
            {
                transform.Translate(Vector2.right * Player_Speed * Time.deltaTime);//오른쪽으로 speed만큼 이동
            }
            if (Input.GetKey(KeyCode.UpArrow))//위를 눌렀다면
            {
                transform.Translate(Vector2.up * Player_Speed * Time.deltaTime);//위로 speed만큼 이동
            }
            if (Input.GetKey(KeyCode.DownArrow))//아래를 눌렀다면
            {
                transform.Translate(Vector2.down * Player_Speed * Time.deltaTime);//아래로 speed만큼 이동
            }
            if (Input.GetKeyDown(KeyCode.Space))//스페이스바를 눌렀다면
            {
                Instantiate(laser, this.transform.position, Quaternion.identity);
                //레이저를 자기 자신의 위치에서 생성한다
            }
        }
    }
}
