using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//player controller
public class AnimacionPersonaje : MonoBehaviour
{
    public static AnimacionPersonaje instance;
    // Start is called before the first frame update
    [Header("Salto")]
    public float jumpForce; //salto
    public float bounceforce;
    [Header("Movimiento")]
    bool voltear = true; //voltear
    public float maxVelocidad; // velocidad

    [Header("Componentes")]
    
    Rigidbody2D rigid; //rigidbody
    SpriteRenderer Render; // sprite render

    [Header("Grounded")]
    private bool isGrounded;
    private bool doubleJump;
    public Transform groundCheckpoint; 
    public LayerMask whatIsGround;

    [Header("Animator")]
     public Animator anim; // animatoir

     public float longitud, empuje;
     private float longicounter;

     public int clickCounter;
     public bool clickPosibility;

     public bool stopInput;

    private void Awake(){
        instance = this;
        // el GetComponentInChildren es por que el animator esta dentro del player
        anim = GetComponentInChildren<Animator>();
        rigid = GetComponentInChildren<Rigidbody2D> ();
        Render = GetComponentInChildren<SpriteRenderer> ();
    }
    void Start()
    {
        clickPosibility = true;
        clickCounter = 0;
    }


    // Update is called once per frame
    void Update()
    {
         /*Explicacion de GetButton
        GetButtonDown -> cuando se presiona el boton
        GetButtonUp -> cuando se suelta el boton 
        GetButton -> corre desde que presionas hasta que se quita el dedo*/
        if(!stopInput){
            if(longicounter <= 0){ //cuando se haga daño el jugador tendra un efecto por esto



            isGrounded = Physics2D.OverlapCircle(groundCheckpoint.position, 2f, whatIsGround); //detectar el piso
            if(isGrounded){
                doubleJump = true;
            }
            //fuerza de salto
            if(Input.GetButtonDown("Jump")){
                if(isGrounded){
                    rigid.velocity = new Vector2(rigid.velocity.x,jumpForce);
                }else{
                    if(doubleJump){
                        rigid.velocity = new Vector2(rigid.velocity.x,jumpForce);
                        doubleJump = false;
                    }
                }
            }
            //ANIMACIONES//

            //ataque
            if(Input.GetMouseButtonDown(0)){
                startCombo();
                /*
                //anim.SetTrigger("Ataque");
                if(clickPosibility && clickCounter < 3){
                    clickCounter++;
                    anim.SetInteger("Atack", clickCounter);
                    clickPosibility = false;
                }*/
            }
            if(anim.GetCurrentAnimatorStateInfo(0).IsName("idle") && clickCounter == 0){
                    clickPosibility = true;
            }
            



            // Movimiento y giro
            float mov = Input.GetAxis("Horizontal");

            if(mov > 0 && !voltear)
            {
                Funvoltear();
            }
            else if( mov < 0 && voltear)
            {
                Funvoltear();
            }

            rigid.velocity = new Vector2(maxVelocidad * mov , rigid.velocity.y);

        }else {
            longicounter -= Time.deltaTime;

            if(!Render.flipX){ //empuja al jugador a un lado cuando se hace daño
                rigid.velocity = new Vector2(-empuje, rigid.velocity.y);
            }else {
                rigid.velocity = new Vector2(+empuje, rigid.velocity.y);
            }
        }
        
       
       anim.SetFloat("moveSpeed", Mathf.Abs(rigid.velocity.x));
       anim.SetBool("isGrounded", isGrounded);
        }

        
    }

    void Funvoltear()
    {
        voltear = !voltear;
        Render.flipX = !Render.flipX;
    }

    public void Knockback(){
        longicounter = longitud;
        rigid.velocity = new Vector2(0f, empuje);
    }

    public void startCombo(){
        if(clickPosibility){
            clickCounter++;
        }

        if(clickCounter == 1){
            anim.SetInteger("Atack",1);
        }

        if(clickCounter == 2){
            anim.SetInteger("Atack",2);
        }

        if(clickCounter == 3){
            anim.SetInteger("Atack",3);
        }
    }
    public void verificaCombo(){
        /*
        if(clickPosibility){
            clickPosibility = false;
            clickCounter = 0;
            anim.SetInteger("Atack", clickCounter);
        }*/

        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Ataque 0") && clickCounter == 1){ //si esta en ataque 0 y solo puso click una vez 
                    anim.SetInteger("Atack", 0); //va a idle
                    clickPosibility = true;
                    clickCounter = 0;
            }else if(anim.GetCurrentAnimatorStateInfo(0).IsName("Ataque 0") && clickCounter >= 2){ //ademas si esta en ataque 0 y da click dos veces
                anim.SetInteger("Atack",2); //va al ataque 1
                clickPosibility = true;
            }else if(anim.GetCurrentAnimatorStateInfo(0).IsName("Ataque1") && clickCounter == 2){
                anim.SetInteger("Atack",0);
                clickPosibility = true;
            }else if(anim.GetCurrentAnimatorStateInfo(0).IsName("Ataque1") && clickCounter >=3){
                anim.SetInteger("Atack",3);
                clickPosibility = true;
            }else if(anim.GetCurrentAnimatorStateInfo(0).IsName("Ataque2") && clickCounter == 1){
                anim.SetInteger("Atack",0);
                clickPosibility = true;
                clickCounter = 0;
            }
    }

    public void Bounce(){ //efecto golpe con la espada
        rigid.velocity = new Vector2(bounceforce, rigid.velocity.y);
    }
}
