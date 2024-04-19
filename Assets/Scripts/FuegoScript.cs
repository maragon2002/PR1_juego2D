using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuegoScript : MonoBehaviour
{
    bool bolaDerecha;
    GameObject personaje;
    // Start is called before the first frame update
    void Start()
    {
       personaje=GameObject.Find("Personaje");
       bolaDerecha=personaje.GetComponent<MovPersonaje>().mirandoDerecha;
    }

    // Update is called once per frame
    void Update()
    {
        if(bolaDerecha){
        transform.Translate(0.01f,0,0,Space.World);
        }else{
             transform.Translate(-0.01f,0,0,Space.World);
        }
       
    }

    void OnTriggerEnter2D(Collider2D col){
       // Debug.Log(col.gameObject.name.StartsWith("fantasma"));

        if (col.gameObject.name.StartsWith("fantasma")){
            Destroy(col.gameObject);

        }

    }
}
