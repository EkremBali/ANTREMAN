using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eagle : MonoBehaviour
{
    Vector2 kartalPos;
    Vector2 kartalBas;

    public Transform ucgen;
    Vector2 ucgenPos;
    Vector2 ucgenBas;

    bool solKenar = false;
    bool sagKenar = false;

    public void Start()
    {
        kartalPos = transform.position;
        kartalBas = transform.position;

        ucgenBas = ucgen.position;
        ucgenPos = ucgen.position;
    }
    void Update()
    {
        if (solKenar)
        {
            transform.rotation = new Quaternion(0, 180, 0,0);
            KartalSag();
            
        }
        if (sagKenar)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            transform.position = kartalBas;
            ucgen.position = ucgenBas;
        }
        if(solKenar==false&&sagKenar==false)
        {
            KartalSol();
        }
    }
    void KartalSol()
    {
        kartalPos.x -= 0.03f;
        transform.position = kartalPos;
        ucgenPos.x -= 0.03f;
        ucgen.position = ucgenPos;
    }
    void KartalSag()
    {
        kartalPos.x += 0.03f;
        transform.position = kartalPos;
        ucgenPos.x += 0.03f;
        ucgen.position = ucgenPos;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("solKolon"))
        {
            Debug.Log("sol girdi");
            solKenar = true;
            sagKenar = false;
            ucgen.position = new Vector2(-5f, -0.21f);
        }
        if (collision.gameObject.CompareTag("sagKolon"))
        {
            Debug.Log("sag girdi");
            sagKenar = true;
            solKenar = false;
        }
    }
}
