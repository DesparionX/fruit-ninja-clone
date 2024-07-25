using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour {

    public GameObject slicedFruitPrefab;
    public int points;

    public void CreateSlicedFruit(){

        GameObject inst = (GameObject)Instantiate(slicedFruitPrefab, transform.position, transform.rotation);


        Rigidbody[] rbsOnSliced = inst.transform.GetComponentsInChildren<Rigidbody>();
        inst.GetComponent<AudioSource>().Play();
        foreach(Rigidbody r in rbsOnSliced){
            r.transform.rotation = Random.rotation;
            r.AddExplosionForce(Random.Range(100, 500), transform.position, 5f);
        }

        Destroy(gameObject);
        Destroy(inst.gameObject, 5);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Blade b = collision.GetComponent<Blade>();
        if (!b)
        {
            return;
        }
        else
        {
            collision.GetComponent<AudioSource>().Play();
            CreateSlicedFruit();
            FindObjectOfType<GameManager>().IncreaseScore(points);
        }
    }

}
