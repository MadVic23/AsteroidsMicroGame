using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
 public float speed = 10f;
 public float maxLifeTime = 3f;
 public Vector3 targetVector;
 public GameObject asteroidPrefab;
 Vector3 x = new Vector3(1.5f,0f,0f);

 void Start()
 {
 // nada más nacer, le damos unos segundos de vida,
 // lo suficiente para salir de la pantalla
 Destroy(gameObject, maxLifeTime);
 }
 void Update()
 {
 // la bala se mueve en la dirección del jugador al disparar
 transform.Translate(targetVector * speed * Time.deltaTime);
 }
 private void OnCollisionEnter(Collision collision){
    if(collision.gameObject.tag == "Enemy"){
        IncreaseScore();
        Vector3 spawnPosition = collision.gameObject.transform.position;
        spawnPosition = spawnPosition + x;
        GameObject meteor = Instantiate(asteroidPrefab,spawnPosition,Quaternion.identity);
        spawnPosition = spawnPosition - x;
        GameObject meteor2 = Instantiate(asteroidPrefab,spawnPosition,Quaternion.identity);
        Destroy(collision.gameObject);
        Destroy(gameObject);
        Destroy(meteor,4f);
        Destroy(meteor2,4f);
    }
    if(collision.gameObject.tag == "Enemy2"){
        IncreaseScore();
        IncreaseScore();
        Destroy(collision.gameObject);
        Destroy(gameObject);

    }
 }

 private void OnTriggerEnter(Collider other)
 {
 if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Enemy2" )
 Destroy(other.gameObject);
 }

 private void IncreaseScore(){
    Player.SCORE++;
    UpdateScoreText();
 }

 private void UpdateScoreText(){
    GameObject go = GameObject.FindGameObjectWithTag("UI");
    go.GetComponent<Text>().text = "" + Player.SCORE;
 }


}
