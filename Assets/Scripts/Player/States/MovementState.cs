using UnityEngine;
using System.Collections;

public class MovementState : State<Player> {

    private Player player;
    private Vector2 movementInputVector;

    private Vector2 previousInputVector;

    public MovementState(Player playerInstance, StateMachine<Player> fsm)
        : base(playerInstance, fsm)
    {
        player = playerInstance;
    }

    override public void Enter()
    {
        movementInputVector = Controls.getDirection(player);
    }

    override public void Execute()
    {
        previousInputVector = movementInputVector;
        movementInputVector = Controls.getDirection(player);

        //Might want to change this stuff later to include transition states
        if (movementInputVector.x == 0 || (previousInputVector.x == 1.0f && movementInputVector.x < 1.0f))
        {
            player.ActionFsm.ChangeState(new IdleState(player, player.ActionFsm));
            return;
        }

        if (Controls.jumpInputDown(player) || !player.grounded)
        {
            player.ActionFsm.ChangeState(new AirState(player, player.ActionFsm));
            return;
        }

        //Temporary measures until we get more animations.
        player.anim.SetFloat("DirX", Mathf.Sign(movementInputVector.x));
        player.anim.SetFloat("MoveSpeed", Mathf.Abs(movementInputVector.x));
        //player.anim.SetFloat("DirY", Mathf.Ceil(Parameters.getVector(player.direction).y));
    }

    override public void FixedExecute()
    {
        if(Mathf.Abs(movementInputVector.x) == 1)
            player.selfBody.velocity = new Vector2(Mathf.Sign(movementInputVector.x) * player.runSpeed, player.selfBody.velocity.y);
        else
            player.selfBody.velocity = new Vector2(movementInputVector.x * player.walkSpeed, player.selfBody.velocity.y);
    }

    override public void Exit()
    {
        return;
    }
}
