using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hp : MonoBehaviour
{
    public float powerEnemy = 1; //攻撃力
    [SerializeField]
    private float hp = 1;//体力
    // Start is called before the first frame update
    void Start()
    {

       
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);  //ゲームオブジェクトが破壊される
        }
    }
    public void Damege()
    {
        hp--;
    }
}
