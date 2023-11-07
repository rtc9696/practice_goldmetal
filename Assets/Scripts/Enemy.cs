using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;

    SpriteRenderer spriter;
    Rigidbody2D rigid;
    Animator anim;
    bool isLive = true;
    public Rigidbody2D target;
    Vector2 targetDir;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriter = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        if (!isLive)
            return;

        targetDir = target.position - rigid.position;
        rigid.MovePosition(rigid.position + targetDir.normalized * speed * Time.fixedDeltaTime);
        rigid.velocity = Vector2.zero;
    }
    private void LateUpdate()
    {
        if (!isLive)
            return;

        spriter.flipX = target.transform.position.x - transform.position.x < 0;
    }

    //스크립트가 활성화될 때 실행한다.
    private void OnEnable()
    {
        target = GameManager.Instance.player.GetComponent<Rigidbody2D>();
    }
}

