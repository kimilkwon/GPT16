using UnityEngine;
using System.Collections;

public class Center : MonoBehaviour {

    Enemy_One EnemyOne;
    PlayerCtrl PlayerOne;

    public GameObject Enemy;
    public GameObject Player;
    Vector3 PlayerPosition = new Vector3(0, -4, 0);
    Vector3 EnemyPosition = new Vector3(0, 4, 0);

    // Use this for initialization
    void Start () {
        EnemyOne = Enemy.GetComponent<Enemy_One>();
        PlayerOne = Player.GetComponent<PlayerCtrl>();
        Instantiate(Player, PlayerPosition, Quaternion.identity);
        Instantiate(Enemy, EnemyPosition, Quaternion.identity);
    }
	void Awake()
    {
        
    }
	// Update is called once per frame
	void Update () {
	
	}
}
