using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    // desde este punto se verifica el contacto con el suelo para saltar correctamente
    public GameObject feet;
    // layer en el cual se realiza el raycast2d para ver si el character esta tocando el suelo
    public LayerMask layerMask;
    
    Rigidbody2D rb2d;
    SpriteRenderer sr;
    Animator anim;
    private float speed = 5f;
    private float jumpForce = 250f;
    private bool facingRight = true;
 


	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
	

	void Update () {
        float move = Input.GetAxis("Horizontal");
        if (move != 0) {
            rb2d.transform.Translate(new Vector3(1, 0, 0) * move * speed * Time.deltaTime);
            facingRight = move > 0;
        }

        anim.SetFloat("Speed", Mathf.Abs(move));

        sr.flipX = !facingRight;

        if (Input.GetButtonDown("Jump"))
        {
            // verificar que el character este tocando el suelo antes de saltar
            RaycastHit2D hitInfo = Physics2D.Raycast(feet.transform.position, Vector2.down, 0.1f, layerMask);
            if(hitInfo.collider != null)
                rb2d.AddForce(Vector2.up*jumpForce);
        }
	}
}
