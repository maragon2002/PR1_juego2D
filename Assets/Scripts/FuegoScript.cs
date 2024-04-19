using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuegoScript : MonoBehaviour
{
    bool bolaDerecha;
    GameObject personaje;

    float tiempoDestruccion=5,0f;

    float queHoraEs;

    // Start is called before the first frame update
    void Start()
    {
       personaje=GameObject.Find("Personaje");
       bolaDerecha=personaje.GetComponent<MovPersonaje>().mirandoDerecha;
       queHoraEs=Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(bolaDerecha){
        transform.Translate(0.01f,0,0,Space.World);
        }else{
             transform.Translate(-0.01f,0,0,Space.World);
        }
       
    if(Time.time>= queHoraEs+tiempoDestruccion){
        Destroy(this.gameObject);
    }
    }

    void OnTriggerEnter2D(Collider2D col){
       // Debug.Log(col.gameObject.name.StartsWith("fantasma"));

        if (col.gameObject.name.StartsWith("fantasma")){
           
            Destroy(col.gameObject);
            GameManager.muertes +=1;

        }

    }
}
