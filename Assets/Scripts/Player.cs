using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;

    public VariableJoystick joy;

    public Vector2 moveVec;


    public float speed;

    void Awake() 
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void FixedUpdate()
    {

        // ���̽�ƽ x, y �� �Ҵ�
        float x = joy.Horizontal;
        float y = joy.Vertical;
        // �̵� ����
        moveVec = new Vector2(x, y);
        rigid.MovePosition(rigid.position + moveVec.normalized * speed * Time.fixedDeltaTime);

        
    }
    void LateUpdate()
    {
        // �ִϸ��̼� ���ǵ� ���ڰ��� ũ��(moveVec)�� ������.
        anim.SetFloat("Speed", moveVec.magnitude);
        
        // ĳ���� ���� ��ȯ
        if (moveVec.x != 0)
        {
            spriter.flipX = moveVec.x < 0;

        }
    }
}
