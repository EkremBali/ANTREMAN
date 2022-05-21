using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    public Transform cam;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("cali"))
        {
            transform.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("cali"))
        {
            transform.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    void Update()
    {



        //if (Input.touchCount > 0)
        //{
        //    Touch[] touches = Input.touches;

        //    for(int i = 0; i<touches.Length; i++)
        //    {
        //        Vector2 ray = Camera.main.ScreenToWorldPoint(touches[i].position);
        //        RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);

        //        if (touches[i].phase == TouchPhase.Began)
        //        {
        //            if (hit.collider.name == "forward")
        //            {
        //                transform.Translate(Vector2.right * Time.deltaTime * 10);
        //            }
        //            else if (hit.collider.name == "back")
        //            {
        //                transform.Translate(Vector2.left * Time.deltaTime * 10);
        //            }
        //            else if (hit.collider.name == "jump")
        //            {
        //                jumpAnim.Play();
        //            }
        //        }
        //    }

        Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);

        if(hit.collider != null)
        {
            if (hit.collider.name == "forward")
            {
                animator.SetBool("walk", true);
                float x = transform.position.x;
                float y = transform.position.y;
                x += .01f;
                transform.position = new Vector2(x, y);

                float xc = cam.transform.position.x;
                float yc = cam.transform.position.y;
                xc += .01f;
                cam.position = new Vector3(xc, yc, -1);

            }
            else if (hit.collider.name == "back")
            {
                transform.rotation = new Quaternion(0, 180, 0, 0);
                animator.SetBool("walk", true);
                float x = transform.position.x;
                float y = transform.position.y;
                x -= .01f;
                transform.position = new Vector2(x, y);

                float xc = cam.transform.position.x;
                float yc = cam.transform.position.y;
                xc -= .01f;
                cam.position = new Vector3(xc, yc, -1);
            }
            else
            {
                animator.SetBool("walk", false);
            }
        }
        else
        {
            animator.SetBool("walk", false);
        }

    }

    public void jump()
    {
        rb.velocity = Vector2.up * 6f;
        animator.SetTrigger("jump");
    }



}

