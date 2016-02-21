using UnityEngine;
using System.Collections;

public class DownSuperState : State<Player>
{
    private Player player;

    private float groundAnimEndlag;
    private float landingAnimEndlag;

    private float endlag;
    private float timer;

    public DownSuperState(Player playerInstance, StateMachine<Player> fsm) : base(playerInstance, fsm)
    {
        Time.timeScale = 0.7f;
        timer = 0;
        player = playerInstance;
    }

    override public void Enter()
    {
        Debug.Log("entered attack state");
        if (player.grounded)
            endlag = groundAnimEndlag;
        else
            endlag = landingAnimEndlag;

        player.hitboxManager.activateHitBox("StompHitbox");
    }

    override public void Execute()
    {
        if (player.grounded)
        {
            timer += Time.deltaTime;
            if (timer > endlag)
                player.ActionFsm.ChangeState(new IdleState(player, player.ActionFsm));
        }
    }

    override public void FixedExecute()
    {
        if (!player.grounded)
            player.selfBody.velocity = new Vector2(0, -20.0f);
    }

    override public void Exit()
    {
        Time.timeScale = 1.0f;
        player.hitboxManager.deactivateHitBox("StompHitbox");
    }
}
