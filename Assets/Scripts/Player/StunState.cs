using UnityEngine;
using System.Collections;

public class StunState : State<Player>
{

    private Player player;
    private float regeneratedHealth = 0.0f;
    private float regenRate = 5.0f;

    public StunState(Player playerInstance, StateMachine<Player> fsm)
        : base(playerInstance, fsm)
    {
        player = playerInstance;
    }

    override public void Enter()
    {
        player.isStunned = true;
    }

    override public void Execute()
    {
        if (regeneratedHealth <= player.maxHealth)
            regeneratedHealth += Time.deltaTime * regenRate;
        else
            player.ActionFsm.ChangeState(new IdleState(player, player.ActionFsm));
    }

    override public void FixedExecute()
    {
    }

    override public void Exit()
    {
        player.isStunned = false;
    }
}
