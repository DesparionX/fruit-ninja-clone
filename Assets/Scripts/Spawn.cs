using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] fruitToSpawn;
    public GameObject bomb;
    public Transform[] spawnPlaces;
    public Transform[] spawnBombPlaces;

    public Vector3 bombRotation;

    public float minWait = 2f;
    public float maxWait = 4f;

    void Start()
    {
        StartCoroutine(SpawnObjects());
    }
    private IEnumerator SpawnObjects()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWait, maxWait));

            Transform t;
            var chance = Random.Range(0, 100);
            if (chance <= 5)
            {
               if(Random.Range(0,100) <= 50)
                {
                    t = spawnBombPlaces[Random.Range(0, spawnBombPlaces.Length)];
                    SpawnBombFromSky(t);
                }
                else
                {
                    t = spawnPlaces[Random.Range(0, spawnPlaces.Length)];
                    SpawnBombFromBottom(t);
                }
            }
            else
            {
                t = spawnPlaces[Random.Range(0, spawnPlaces.Length)];
                SpawnFruit(t);
            }
        }
    }
    private void SpawnBombFromSky(Transform tr)
    {
        GameObject go = bomb;
        GameObject obj = Instantiate(go, tr.position, Quaternion.Euler(bombRotation));

        if (tr.position.x > 0)
            obj.GetComponent<Rigidbody2D>().AddForce(Vector2.left * Random.Range(2, 4), ForceMode2D.Impulse);
        else
            obj.GetComponent<Rigidbody2D>().AddForce(Vector2.right * Random.Range(2, 4), ForceMode2D.Impulse);

        GetComponent<AudioSource>().Play();
        Destroy(obj, 10);
    }
    private void SpawnBombFromBottom(Transform tr)
    {
        GameObject go = bomb;
        GameObject obj = Instantiate(go, tr.position, Quaternion.Euler(bombRotation));
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();

        rb.gravityScale = 1;
        rb.AddForce(tr.transform.up * Random.Range(14, 20), ForceMode2D.Impulse);

        GetComponent<AudioSource>().Play();
        Destroy(obj, 10);
    }
    private void SpawnFruit(Transform tr)
    {
        GameObject go = fruitToSpawn[Random.Range(0, fruitToSpawn.Length)];
        GameObject obj = Instantiate(go, tr.position, tr.rotation);

        obj.GetComponent<Rigidbody2D>().AddForce(tr.transform.up * Random.Range(14, 20), ForceMode2D.Impulse);

        GetComponent<AudioSource>().Play();
        Destroy(obj, 5);
    }
}
