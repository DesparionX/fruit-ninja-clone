using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    //public AudioClip[] whooshes;
    public float minDistance = 0.2f;
    public float minSpeed = 0.1f;

    private float traveledDistance;

    private Rigidbody2D rb;
    private Collider2D col;
    private TrailRenderer tr;
    private AudioSource sound;

    private Vector3 lastMousePos = Vector3.zero;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        tr = GetComponent<TrailRenderer>();
        sound = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        MakeBladeFollowMouse();
        col.enabled = IsBladeMoving();
        //Debug.Log(traveledDistance.ToString());
    }

    private void MakeBladeFollowMouse()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 10;
        rb.position = Camera.main.ScreenToWorldPoint(mousePos);
    }
    private void PlayWhoosh()
    {
        sound.Play();
    }
    private bool IsBladeMoving()
    {
        var curMousePos = transform.position;
        traveledDistance = (lastMousePos - curMousePos).magnitude;
        lastMousePos = curMousePos;

        if (traveledDistance > minDistance)
        {
            tr.enabled = true;
            PlayWhoosh();
            return true;
        }
        else
        {
            tr.enabled = false;
            return false;
        }
    }
}
