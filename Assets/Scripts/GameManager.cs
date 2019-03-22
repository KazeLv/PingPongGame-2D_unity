using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Text score1Text;
    public Text score2Text;

    private static GameManager _instance;
    public static GameManager instance {
            get {
            return _instance;
            }
    }

    private int score1, score2;

    private BoxCollider2D upWall;
    private BoxCollider2D downWall;
    private BoxCollider2D rightWall;
    private BoxCollider2D leftWall;

    public Transform Player1;
    public Transform Player2;
    public float distance;//The distance between palayers and walls;

    void Awake()
    {
        _instance = this;
    }

	// Use this for initialization
	void Start () {
        ResetWall();
        ResetPlayer();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void ResetWall()
    {
        upWall = transform.Find("upWall").GetComponent<BoxCollider2D>();
        downWall = transform.Find("downWall").GetComponent<BoxCollider2D>();
        rightWall = transform.Find("rightWall").GetComponent<BoxCollider2D>();
        leftWall = transform.Find("leftWall").GetComponent<BoxCollider2D>();

        //Vector3 upWallPosition = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width/2, Screen.height));
        //Vector3 downWallPosition = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2, 0));
        //Vector3 rightWallPosition = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height / 2));
        //Vector3 leftWallPosition = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height / 2));
        //
        //upWall.transform.position = upWallPosition+new Vector3(0,0.5f,0);
        //downWall.transform.position = downWallPosition+new Vector3(0,-0.5f,0);
        //rightWall.transform.position = rightWallPosition+new Vector3(0.5f,0,0);
        //leftWall.transform.position = leftWallPosition+new Vector3(-0.5f,0,0);
        //
        //float upWallLength = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x * 2;
        //float downWallLength = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x * 2;
        //float rightWallLength = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).y * 2;
        //float leftWallLength = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).y * 2;
        //
        //upWall.size =new Vector2(upWallLength,1);
        //downWall.size = new Vector2(downWallLength, 1);
        //rightWall.size = new Vector2(1, rightWallLength);
        //leftWall.size = new Vector2(1, leftWallLength);

        Vector3 tempPosition = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        upWall.size = new Vector2(tempPosition.x * 2, 1);
        downWall.size = new Vector2(tempPosition.x * 2, 1);
        rightWall.size = new Vector2(1,tempPosition.y*2);
        leftWall.size = new Vector2(1, tempPosition.y * 2);

        upWall.transform.position = new Vector3(0, tempPosition.y + 0.5f, 0);
        downWall.transform.position = new Vector3(0, -tempPosition.y - 0.5f, 0);
        rightWall.transform.position = new Vector3(tempPosition.x + 0.5f, 0, 0);
        leftWall.transform.position = new Vector3(-tempPosition.x - 0.5f, 0, 0);
    }

    void ResetPlayer()
    {
        Vector3 player1Position = Camera.main.ScreenToWorldPoint(new Vector2(distance, 0));
        player1Position.z = 0;
        Vector3 player2Position = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width - distance, 0));
        player2Position.z = 0;
    }
    public void ChangeScore(string wallName)
    {
        if (wallName == "leftWall")
        {
            score2++;
        }else
        {
            score1++;
        }
        score1Text.text = score1.ToString();
        score2Text.text = score2.ToString();
    }
    public void ResetGame()
    {
        score1 = 0;
        score2 = 0;
        score1Text.text = score1.ToString();
        score2Text.text = score2.ToString();
        GameObject.Find("Ball").SendMessage("ResetBall");
    }
}
