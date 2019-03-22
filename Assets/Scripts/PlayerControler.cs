using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour {

    private AudioSource audio;

    public KeyCode upKey;
    public KeyCode downKey;
    public float speed = 4;

    private Rigidbody2D rigidbody2D;
	// Use this for initialization
	void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(upKey))
        {
            rigidbody2D.velocity = new Vector2(0, speed);
        }else if (Input.GetKey(downKey))
        {
            rigidbody2D.velocity = new Vector2(0, -speed);
        }
        else
        {
            rigidbody2D.velocity = new Vector2(0, 0);
        }
	}
    void OnCollisionEnter2D()
    {
        audio.pitch = Random.Range(0.7f, 1.3f);
        audio.Play();
    }
}
