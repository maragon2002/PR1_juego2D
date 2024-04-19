using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FantasmaScript : MonoBehaviour
{
    Vector3 posicionInicial;
    GameObject personaje;
    public float velocidadFantasma=2.0f;
    // Start is called before the first frame update
    void Start()
    {
       posicionInicial=transform.position; 
       personaje=GameObject.Find("Personaje");
    }

    // Update is called once per frame
    void Update()
    {
      float distancia= Vector3.Distance(transform.position,personaje.transform.position);
     
     float velocidadFinal=velocidadFantasma*Time.deltaTime;
     
      if( distancia <=4.1f){
        //ACCION
        //Debug.DrawLine(transform.position,personaje.transform.position,Color.red,2.5f);
       
        
        transform.position=Vector3.MoveTowards(transform.position,personaje.transform.position,velocidadFinal);
      }else{
        //VUELTA A CASA
        //Debug.DrawLine(transform.position,personaje.transform.position,Color.white,2.5f);
        transform.position=Vector3.MoveTowards(transform.position,posicionInicial,velocidadFinal);
      }
        // Debug.Log(distancia);
       // Debug.DrawLine(transform.position,personaje.transform.position,Color.white,2.5f);
    }
     
}
