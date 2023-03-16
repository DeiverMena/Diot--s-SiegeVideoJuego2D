using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;

    public Transform leftPoint, rightPoint;

    private bool movingRight;

    private Rigidbody2D rigid;

    public SpriteRenderer render;

    public float moveTime, waitTime;
    private float moveCount, waitcount;

    private Animator animEnemy;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animEnemy = GetComponent<Animator>();

        leftPoint.parent = null;
        rightPoint.parent = null;

        movingRight = true;
        moveCount = moveTime;

    }

    // Update is called once per frame
    void Update()
    {
        if(moveCount > 0){ //movimiento de rana menos robotico
        moveCount -= Time.deltaTime;
            if(movingRight){ //si la rana se mueve a la derecha
                rigid.velocity = new Vector2(moveSpeed, rigid.velocity.y);
                render.flipX =true;

                if(transform.position.x > rightPoint.position.x){ //giro de la rana
                    movingRight = false;
            }
         }else {
                rigid.velocity = new Vector2(-moveSpeed, rigid.velocity.y); //movespeed es negativo porque ahora se mueve a la izquierda
                render.flipX = false;

                if(transform.position.x < leftPoint.position.x){ //giro de la rana
                    movingRight = true;
                }

            }
            if(moveCount <= 0){//si Mcount es menor a cero
                waitcount = Random.Range(waitTime * 0.75f,waitTime * 1.25f ); //hace paradas random
            }

            animEnemy.SetBool("isMoving", true);

        }else if(waitcount > 0){
            waitcount -= Time.deltaTime;
            rigid.velocity = new Vector2(0f, rigid.velocity.y);

            if(waitcount <= 0){//si Mcount es menor a cero
                moveCount = Random.Range(waitTime * 0.75f,waitTime * 1.25f );
            }
            animEnemy.SetBool("isMoving", false);

        }
        
    }
}
