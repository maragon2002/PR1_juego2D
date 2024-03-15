using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MovPersonaje : MonoBehaviour
{

    public float multiplicadorVelocidad = 5;
    public float multiplicadorSalto=5;
    bool puedoSaltar=true;
    
    Rigidbody2D rb;

    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
       sr= this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {


        //MOVIMIENTO

        float mov = Input.GetAxis("Horizontal") * multiplicadorVelocidad * Time.deltaTime;
        // transform.position=new Vector3(transform.position.x+mov,transform.position.y,transform.position.z);
        transform.Translate(mov, 0, 0);
        if(Input.GetKeyDown(KeyCode.A)){
            sr.flipX=true;
        
        }
        if(Input.GetKeyDown(KeyCode.D)){
            sr.flipX=false;
        
        }
        
        //SALTO

        RaycastHit2D hit;
        hit= Physics2D.Raycast(transform.position,Vector2.down,0.5f);
     
        Debug.Log(hit.collider.name);

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
    }



void OnCollisionEnter2D (Collision2D col){
Debug.Log(col.gameObject.name);
}


}








