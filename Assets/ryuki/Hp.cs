using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hp : MonoBehaviour
{
    public float powerEnemy = 1; //�U����
    [SerializeField]
    private float hp = 1;//�̗�
    // Start is called before the first frame update
    void Start()
    {

       
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);  //�Q�[���I�u�W�F�N�g���j�󂳂��
        }
    }
    public void Damege()
    {
        hp--;
    }
}
