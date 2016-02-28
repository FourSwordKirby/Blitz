using UnityEngine;
using System.Collections;

public class DownSuperState : State<Player>
{
    private Player player;

    private float superFlashTime;

    private float groundAnimEndlag;
    private float landingAnimEndlag;

    private float endlag;
    private float timer;

    public DownSuperState(Player playerInstance, StateMachine<Player> fsm) : base(playerInstance, fsm)
    {
        Time.timeScale = 0.2f;
        player = playerInstance;
        superFlashTime = 0.1f;
        groundAnimEndlag = 0.1f;
        landingAnimEndlag = 0.3f;
    }

    override public void Enter()
    {
        if (player.grounded)
            endlag = groundAnimEndlag;
        else
            endlag = landingAnimEndlag;
        timer = 0;

        player.hitboxManager.activateHitBox("StompHitbox");
    }

    override public void Execute()
    {
        superFlashTime -= Time.deltaTime;
        if (superFlashTime < 0)
            Time.timeScale = 1.0f;

        if (player.grounded)
        {
            timer += Time.deltaTime;
            if (timer > endlag)
                player.ActionFsm.ChangeState(new IdleState(player, player.ActionFsm));
        }

        //Canceling into a jump if it is available
        if (superFlashTime < 0 && Controls.jumpInputDown(player) && player.airJumps < player.maxAirJumps)
        {
            player.airJumps++;
            player.selfBody.velocity = new Vector2(player.selfBody.velocity.x, player.jumpHeight);
            player.ActionFsm.ChangeState(new AirState(player, player.ActionFsm));
            return;
        }
    }

    override public void FixedExecute()
    {
        if (!player.grounded)
        {
            if(Time.timeScale == 1.0f)
                player.selfBody.velocity = new Vector2(0, -20.0f);
            else
                player.selfBody.velocity = new Vector2(0, -2.0f);
        }
    }

    override public void Exit()
    {
        Time.timeScale = 1.0f;
        player.hitboxManager.deactivateHitBox("StompHitbox");
    }
}
