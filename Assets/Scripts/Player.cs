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

        // 조이스틱 x, y 값 할당
        float x = joy.Horizontal;
        float y = joy.Vertical;
        // 이동 관련
        moveVec = new Vector2(x, y);
        rigid.MovePosition(rigid.position + moveVec.normalized * speed * Time.fixedDeltaTime);

        
    }
    void LateUpdate()
    {
        // 애니메이션 스피드 인자값의 크기(moveVec)를 정해줌.
        anim.SetFloat("Speed", moveVec.magnitude);
        
        // 캐릭터 방향 전환
        if (moveVec.x != 0)
        {
            spriter.flipX = moveVec.x < 0;

        }
    }
}
