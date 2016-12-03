using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GameManager : MonoBehaviour {
	private static GameManager instance;
	private GameObject tempStateHolder; 
	private TempState tempState;

    public static List<Player> Players;
    public static CameraControls Camera;
    public static Stage stage;
    public static GameObject[] hit_boxes;

    private static List<GameObject> spawnPoints;

    //Hacky thing used to end the game
    public bool gameOver;

    void Awake()
    {
        /*
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (this != instance)
            {
                Destroy(this.gameObject);
            }
        }
         */

        Camera = GameObject.FindObjectOfType<CameraControls>();
        if (Camera == null)
        {
            Debug.Log("Cannot find camera on the current scene.");
        }

        Players = new List<Player>(GameObject.FindObjectsOfType<Player>());
        if (Players == null)
        {
            Debug.Log("Cannot find players on the current scene.");
        }
       Players.Reverse();

        //We need to sort players based on name....
        //IE, make the player named p1 go into index [0]
        //The players are grabbed kind of arbitrarily otherwise

        stage = GameObject.FindObjectOfType<Stage>();
        if (stage == null)
        {
            Debug.Log("Cannot locate stage");
        }
        spawnPoints = stage.spawnPoints;

        hit_boxes = GameObject.FindObjectsOfType<GameObject>().Where(x => x.GetComponent<Collider2D>() != null).ToArray();
    }

    void Start()
    {
        //Initialize some physics.
		Physics2D.gravity = new Vector2(0.0f, -10.0f);
		tempStateHolder = GameObject.Find ("TempState");
		if (tempStateHolder) {
			tempState = tempStateHolder.GetComponent<TempState> ();
		}
    }

    /*public static void LoadScene(string sceneName, bool persistPlayer = true)
    {
        if (persistPlayer)
            DontDestroyOnLoad(Player);
        else
        {
            Destroy(Player);
            _player = null;
        }

        Application.LoadLevel(sceneName);

        FindPlayer();
        FindCamera();
    }*/


    void Update()
    {
        /*ButtonCheck*/
        if (Controls.attackInputDown(Players[0]))
            Debug.Log("P1 ATTACK");
        if (Controls.specialInputDown(Players[0]))
            Debug.Log("P1 SPECIAL");
        if (Controls.jumpInputDown(Players[0]))
            Debug.Log("P1 JUMP");
        if (Controls.shieldInputDown(Players[0]))
            Debug.Log("P1 SHIELD");
        if (Controls.superInputDown(Players[0]))
            Debug.Log("P1 SUPER");
        if (Controls.pauseInputDown(Players[0]))
            Debug.Log("PAUSE");


		if (!(Players.FindAll (player => player.stocks > 0).Count > 1) && !gameOver) {
			Player winner = Players.FindAll (player => player.stocks > 0).First<Player>();
			Debug.Log ("winner is:");
			Debug.Log (winner.gameObject.name);
            tempState.state["Winner"] = winner.gameObject.name;
            TimeController.SlowDownTime(0.1f);
            gameOver = true;
            GameObject.Find("GameOver").GetComponent<AudioSource>().Play();
            GameObject.FindObjectOfType<ScreenFader>().fadeTime = 4.0f;
            StartCoroutine(this.GetComponent<changeLevel>().EndGame());
            StartCoroutine (this.GetComponent<changeLevel> ().change ("Result Scene"));
		}
    }

    public static void PlayerDeath()
    {
        Camera.Shake();
    }


    //Returns an open position in the specified direction that is at most maxDistance away
    public static Vector2 getOpenLocation(Parameters.InputDirection direction, Vector2 startingPosition, float maxDistance = 1.0f)
    {
        Vector2 newPosition = startingPosition;
        Vector2 increment = new Vector2(0, 0);
        float incrementDistance = 0.1f;
        float currentDistance = 0.0f;

        increment = Parameters.VectorToDir(direction) * incrementDistance;
        while (pointCollides(newPosition))
        {
            currentDistance += incrementDistance;
            newPosition += increment;

            if(currentDistance > maxDistance)
                return startingPosition;
        }
        return newPosition + (10f * currentDistance * increment);
    }

    //Checks if there are any collision boxes over the specified point
    private static bool pointCollides(Vector2 point)
    {
        return System.Array.Exists(hit_boxes, (GameObject hitbox) => hitbox.GetComponent<Collider2D>().bounds.Contains(point));
    }

    public static Vector3 GetRespawnPosition()
    {
        //We will make this pick a location specified by the stage later
        List<GameObject> validSpawn = stage.spawnPoints.Where(x => Players.FindAll(y => y.transform.position == x.transform.position).Count == 0).ToList();
        return validSpawn[Random.Range(0, validSpawn.Count)].transform.position;
    }
}
