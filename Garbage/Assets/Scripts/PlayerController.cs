using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text finalText;
	private Rigidbody2D rb2d;
	private bool facingRight;
	private int count;
	public int vidas;
	public Text textoVidas;
    public AudioClip somCachorro;
    public AudioClip somLata;
    public AudioClip somFundo;

    // Use this for initialization
    void Start () {
		
		rb2d = GetComponent<Rigidbody2D> ();
		count = 0;
		countText.text = "Papeis Coletados: " + count.ToString ();
		finalText.text = "";
		vidas = 3;
		textoVidas.text = "Vidas: " + vidas;
	}

	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
	void FixedUpdate () {
		
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		float jump = 0;

		if (Input.GetKey(KeyCode.Space) && rb2d.position.y < -1.2)
			jump = speed - rb2d.position.y;
		
		Vector3 movement = new Vector3 (moveHorizontal, jump, moveVertical);

		rb2d.AddForce (movement * speed);
		if (moveHorizontal > 0 && facingRight)
			Flip ();
		else if (moveHorizontal < 0 && !facingRight)
			Flip ();

        rb2d.rotation = 0;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("ItemPapel")) {
			other.gameObject.SetActive (false);
			count = count + 1;
			MarcarPonto ();
		}
        if (other.gameObject.CompareTag("Inimigo"))
        {
            PerderVida();
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.clip = somCachorro;
            audioSource.Play();
        }
        if (other.gameObject.CompareTag("Lata"))
        {
            PerderVida();
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.clip = somLata;
            audioSource.Play();
        }
    }

	void MarcarPonto(){
		countText.text = "Papeis Coletados: " + count.ToString ();
		if (count >= 10) {
			finalText.text = "Você Venceu!";
            rb2d.GetComponent<PlayerController>().enabled = false;
        }
	}
    void PerderVida(){
        vidas = vidas - 1;
        textoVidas.text = "Vidas: " + vidas.ToString();
        rb2d.MovePosition(new Vector2(-5,-1));
        if (vidas == 0)
        {
            finalText.text = "Você Perdeu!";
            rb2d.GetComponent<PlayerController>().enabled = false;
        }

    }
}