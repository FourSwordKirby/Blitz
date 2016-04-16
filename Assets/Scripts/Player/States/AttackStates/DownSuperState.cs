using UnityEngine;
using System.Collections;

public class DownSuperState : State<Player>
{
    private Player player;

    private float superFlashTime;

    public float groundAnimEndlag;
    public float landingAnimEndlag;

    private float endlag;
    private float timer;

    public DownSuperState(Player playerInstance, StateMachine<Player> fsm) : base(playerInstance, fsm)
    {
        TimeController.SlowDownTime(0.1f);
        player = playerInstance;
        groundAnimEndlag = 0.1f;
        landingAnimEndlag = 0.2f;
    }

    override public void Enter()
    {
        player.anim.SetBool("Stomp", true);

        player.useMeter(50.0f);
        player.audioManager.play("airstompstart");


        if (player.grounded)
        {
            endlag = groundAnimEndlag;
            GameObject LeftFlame = GameObject.Instantiate(player.projectilePrefabs[1]);
            LeftFlame.GetComponentInChildren<FlameWaveHitbox>().owner = player;
            LeftFlame.transform.position = player.transform.position + new Vector3(-1, 0, 0);
            LeftFlame.GetComponent<Rigidbody2D>().velocity = new Vector3(-4, 0, 0);

            GameObject RightFlame = GameObject.Instantiate(player.projectilePrefabs[1]);
            RightFlame.GetComponentInChildren<FlameWaveHitbox>().owner = player;
            RightFlame.transform.position = player.transform.position + new Vector3(1, 0, 0);
            RightFlame.GetComponent<Rigidbody2D>().velocity = new Vector3(4, 0, 0);
        }
        else
        {
            endlag = landingAnimEndlag;
            player.hitboxManager.activateHitBox("StompHitbox");
        }
        timer = 0;
    }

    override public void Execute()
    {
        if (player.grounded)
        {
            //When we initially land from the air, spawn flames
            if (timer == 0 && endlag == landingAnimEndlag)
            {
                player.audioManager.play("stompland");


                GameObject LeftFlame = GameObject.Instantiate(player.projectilePrefabs[1]);
                LeftFlame.GetComponentInChildren<FlameWaveHitbox>().owner = player;
                LeftFlame.GetComponentInChildren<FlameWaveHitbox>().airborne = true;
                LeftFlame.transform.position = player.transform.position + new Vector3(-1, 0, 0);
                LeftFlame.GetComponent<Rigidbody2D>().velocity = new Vector3(-4, 0, 0);

                GameObject RightFlame = GameObject.Instantiate(player.projectilePrefabs[1]);
                RightFlame.GetComponentInChildren<FlameWaveHitbox>().owner = player;
                RightFlame.GetComponentInChildren<FlameWaveHitbox>().airborne = true;
                RightFlame.transform.position = player.transform.position + new Vector3(1, 0, 0);
                RightFlame.GetComponent<Rigidbody2D>().velocity = new Vector3(4, 0, 0);
            }

            timer += Time.deltaTime;
            if (timer > endlag)
                player.ActionFsm.ChangeState(new IdleState(player, player.ActionFsm));
        }

        //Canceling into a jump if it is available
        if (superFlashTime < 0 && Controls.jumpInputDown(player))
        {
            player.selfBody.velocity = new Vector2(player.selfBody.velocity.x, player.jumpHeight);
            player.ActionFsm.ChangeState(new AirState(player, player.ActionFsm));
            return;
        }
    }

    override public void FixedExecute()
    {
        if (!player.grounded)
        {
            player.selfBody.velocity = new Vector2(0, Mathf.Pow(Time.timeScale, 3.0f) * -20.0f);
            /*
            if(Time.timeScale == 1.0f)
                player.selfBody.velocity = new Vector2(0, -20.0f);
            else
                player.selfBody.velocity = new Vector2(0, -2.0f);
             */
        }
    }

    override public void Exit()
    {
        player.anim.SetBool("Stomp", false);

        Time.timeScale = 1.0f;
        player.hitboxManager.deactivateHitBox("StompHitbox");
    }
}
