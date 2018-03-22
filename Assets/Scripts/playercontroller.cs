using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class playercontroller : MonoBehaviour {
	
    private Rigidbody rb;
    private int count;
	public float speed;
	public Text countText;
    public Text winText;

	private bool onground = false;

	private void Start ()

	{
        rb = GetComponent<Rigidbody>();
        speed = 10;
        count = 0;
        SetCountText();
        winText.text = "";
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
        }
    }


    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if( count >= 12)
        {
            winText.text = "You Win!";
        }
    }


    void FixedUpdate ()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
			Vector3 jump = new Vector3 (0, 250, 0); 

            Vector3 movement = new Vector3(moveHorizontal, 0.15f, moveVertical);

            rb.AddForce(movement * speed);

		if (Input.GetKeyDown(KeyCode.Space) && onground){
			rb.AddForce (jump);
			onground = false;
			}
        }

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.CompareTag("ground")) {
			onground = true;
		}
	
	}
}
