using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour {
    
    enum PlayerState
    {
        Running,
        Sliding,
        Falling
    }

    private Rigidbody2D rbody;
    public GameObject Attractor;
    public GameObject Debris;
    public int DebrisCount;
    public float ForceStrength = 400;
    public float ActionCooldownTime = 2.0f;
    public float AnimationSpeed = 2;

    private float actionCooldown;
    private SpeedManagerBehavior sManager;
    private Animator Animation;
    private BoxCollider2D collider;
    private GameManagerBehavior gManager;
    private SpriteRenderer rend;

	// Use this for initialization
	void Start () {
        rbody = GetComponent<Rigidbody2D>();
        actionCooldown = 0.0f;
        Animation = GetComponent<Animator>();
        sManager = SpeedManagerBehavior.instance;
        gManager = GameManagerBehavior.instance;
        collider = GetComponent<BoxCollider2D>();
        rend = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 DirectionToCenter = Attractor.transform.position - gameObject.transform.position;
        DirectionToCenter.y = 0.0f;
        rbody.AddForce(DirectionToCenter);
        
        if(rbody.velocity.y == 0.0f)
        {
            Animation.SetBool("Falling", false);
        }
        else
        {
            Animation.SetBool("Falling", true);
        }

        if(rbody.velocity.x == 0.0f)
        {
            //gManager.EndGame();
        }

        Animation.speed = sManager.GetCharge() * AnimationSpeed;

        if(!ActionReady())
        {
            actionCooldown -= Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.UpArrow) && ActionReady())
        {
            if(sManager.UsePower())
            {
                rbody.AddForce(Vector2.up * ForceStrength);
                actionCooldown = ActionCooldownTime;
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow) && ActionReady())
        {
            if (sManager.UsePower())
            {
                rbody.AddForce(Vector2.left * ForceStrength);
                actionCooldown = ActionCooldownTime;
            }
        }

        if (Input.GetKey(KeyCode.RightArrow) && ActionReady())
        {
            if (sManager.UsePower())
            {
                rbody.AddForce(Vector2.right * ForceStrength);
                actionCooldown = ActionCooldownTime;
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Animation.SetBool("Sliding", true);
            collider.size = new Vector2(0.32f, 0.16f);
            collider.offset = new Vector2(0.0f, -0.08f);
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            Animation.SetBool("Sliding", false);
            collider.size = new Vector2(0.32f, 0.32f);
            collider.offset = new Vector2(0.0f, 0.0f);
        }
    }

    bool ActionReady()
    {
        return actionCooldown <= 0.0f;
    }

    void KillPlayer()
    {
        rend.enabled = false;
        rbody.Sleep();

        for(int i = 0; i < DebrisCount; i++)
        {
            GameObject o = Instantiate(Debris, transform);
            Rigidbody2D r = o.GetComponent<Rigidbody2D>();
            r.AddForce(new Vector3(Random.Range(-100.0f, 100.0f), Random.Range(-100.0f, 100.0f), 0.0f));
        }

        gManager.EndGame();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CellPickupBehavior cell = collision.GetComponent<CellPickupBehavior>();
        if(cell != null)
        {
            cell.Use();
        }

        ObstacleMovement obs = collision.GetComponent<ObstacleMovement>();
        if(obs != null)
        {
            KillPlayer();
        }
    }
}
