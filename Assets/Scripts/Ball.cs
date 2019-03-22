using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    private Rigidbody2D rigidbody2D;
    public float startForce;

	// Use this for initialization
	void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
        GoBall();
        
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 velocity = rigidbody2D.velocity;
        if (velocity.x >= -9 && velocity.x <= 9 && velocity.x != 0)
        {
            if (velocity.x > 0)
            {
                velocity.x = 10;
            }
            else
            {
                velocity.x = -10;
            }
            rigidbody2D.velocity = velocity;
        }
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Player")
        {
            Vector2 velocity = rigidbody2D.velocity;
            velocity.y = velocity.y / 2 + col.rigidbody.velocity.y / 2;
            rigidbody2D.velocity = velocity;
        }
        if (col.gameObject.name == "leftWall" || col.gameObject.name == "rightWall")
        {
            GameManager.instance.ChangeScore(col.gameObject.name);
        }
    }

    public void ResetBall()
    {
        transform.position = Vector3.zero;
        GoBall();
    }
    void GoBall()
    {
        rigidbody2D.velocity = Vector3.zero;
        int randomStart = Random.Range(0, 2);
        if (randomStart == 0)
        {
            rigidbody2D.AddForce(new Vector2(startForce, 0));

        }
        else
        {
            rigidbody2D.AddForce(new Vector2(-startForce, 0));
        }
    }
    
   
}
