using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
 public float thrustForce = 10f;
 public float rotationSpeed = 120f;
 public static float xBorderLimit, yBorderLimit; 

 public GameObject gun,bulletPrefab;
 private Rigidbody _rigid;

 public static int SCORE = 0;

 public static int LIFES = 3;

 void Start()
 {
 // rigidbody nos permite aplicar fuerzas en el jugador
 _rigid = GetComponent<Rigidbody>();
 yBorderLimit = 20f;
 xBorderLimit = 13.7f; 
 }
 private void FixedUpdate()
 {
 // obtenemos las pulsaciones de teclado
 float rotation = Input.GetAxis("Horizontal") * Time.deltaTime;
 float thrust = Input.GetAxis("Vertical") * Time.deltaTime;
 // la dirección de empuje por defecto es .right (el eje X positivo)
 Vector3 thrustDirection = transform.right;
 // rotamos con el eje "Rotate" negativo para que la dirección sea correcta
 
 // añadimos la fuerza capturada arriba a la nave del jugador
 _rigid.AddForce(thrustForce * thrustDirection * thrust);
 transform.Rotate(Vector3.forward, -rotation*rotationSpeed);

 
 }

 void Update(){
   var newPos = transform.position;
   if(newPos.x > xBorderLimit){
      newPos.x = -7.0f;
   }
    else if(newPos.x < -7.0f){
      newPos.x = 13.3f;
   }
    else if(newPos.y > 16.7f){
      newPos.y = 6.75f;
   }
    else if(newPos.y < 6.75f){
      newPos.y = 16.7f;
   }
   transform.position = newPos;


   if (Input.GetKeyDown(KeyCode.Space)){
    

    GameObject bullet = Instantiate(bulletPrefab,gun.transform.position,Quaternion.identity);
    
    Bullet balaScript = bullet.GetComponent<Bullet>();

    balaScript.targetVector = transform.right;
 
 
 }
 }

 private void OnCollisionEnter(Collision collision){

   if(collision.gameObject.tag == "Enemy"||collision.gameObject.tag == "Enemy2"){
   if(LIFES != 1){
      LIFES--;
      Destroy(collision.gameObject);
   }
   else{
   SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   SCORE = 0;
   LIFES = 3;
      }
   }
   else {
      Debug.Log("He colisionado con otra cosa...");
   }
 }

}

