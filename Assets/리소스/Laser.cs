using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {
    float LaserSpeed = 12f;
    // Use this for initialization
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
