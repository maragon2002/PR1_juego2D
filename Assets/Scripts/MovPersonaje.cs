using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MovPersonaje : MonoBehaviour
{

    public float multiplicadorVelocidad = 5;
    public float multiplicadorSalto=5;
    bool puedoSaltar=true;
    public bool mirandoDerecha=true;
    
    
    Rigidbody2D rb;

    SpriteRenderer sr;

    Animator animatorController;
    public GameObject respawn;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        sr= this.GetComponent<SpriteRenderer>();
        animatorController=this.GetComponent<Animator>();

       // respawn= GameObject.Find("Respawn");
        transform.position=respawn.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
    if (GameManager.estoyMuerto)return;

        //MOVIMIENTO

        float mov = Input.GetAxis("Horizontal") * multiplicadorVelocidad * Time.deltaTime;
        // transform.position=new Vector3(transform.position.x+mov,transform.position.y,transform.position.z);
        transform.Translate(mov, 0, 0);
       
       //flip personaje izquierda
        if(Input.GetKeyDown(KeyCode.A)){
            sr.flipX=true;
            animatorController.SetBool("activacamina",true);
           mirandoDerecha=false;
        }
        //flip personaje derecha
        if(Input.GetKeyDown(KeyCode.D)){
            sr.flipX=false;
            animatorController.SetBool("activacamina",true);
            mirandoDerecha=true;
        }
        if(Input.GetKeyUp(KeyCode.A)||Input.GetKeyUp(KeyCode.D)){
            animatorController.SetBool("activacamina",false);

        }


        //SALTO

        RaycastHit2D hit;
        hit= Physics2D.Raycast(transform.position,Vector2.down,0.5f);
     
        //Debug.Log(hit.collider.name);

        if(hit){
           Debug.Log(hit.collider.name);
             Debug.DrawRay(transform.position,Vector2.down,Color.magenta);
             if(hit.collider.name=="Grid"||hit.collider.name=="Square"){
                puedoSaltar=true;
             }else{
                puedoSaltar=false;
             }
        }else{
            puedoSaltar=false;  

        }



     if(Input.GetKeyDown(KeyCode.Space)&&puedoSaltar==true ){
        rb.AddForce(new Vector2(0,multiplicadorSalto),ForceMode2D.Impulse);
     }

     if(transform.position.y <= -7){
        Respawnear();

    }
    }



void OnCollisionEnter2D (Collision2D col){
Debug.Log(col.gameObject.name);

//0 vidas
if(GameManager.vidas<=0)
{
GameManager.estoyMuerto=true;
}

}




public void Respawnear(){

    Debug.Log("vidas:"+GameManager.vidas);
    GameManager.vidas=GameManager.vidas-1;
    Debug.Log("vidas:"+GameManager.vidas);
    transform.position = respawn.transform.position;
}

}








