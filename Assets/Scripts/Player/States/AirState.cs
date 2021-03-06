﻿using UnityEngine;
using System.Collections;

public class AirState : State<Player>
{
    private Player player;
    private Vector2 movementInputVector;

    public AirState(Player playerInstance, StateMachine<Player> fsm)
        : base(playerInstance, fsm)
    {
        player = playerInstance;
    }

    override public void Enter()
    {
        if (player.grounded)
        {
            player.anim.SetTrigger("Jump");
            player.audioManager.play("jump");
            player.selfBody.velocity = new Vector2(player.selfBody.velocity.x, player.jumpHeight);
        }
        player.grounded = false;
        return;
    }


    /*error with collision boxes puts player in air state when he actually isn't*/
    override public void Execute()
    {
        movementInputVector = Controls.getDirection(player);

        //Might want to change this stuff later to include transition states
        //Check if the player is grounded.
        if (player.grounded)
        {
            player.ActionFsm.ChangeState(new IdleState(player, player.ActionFsm));
            return;
        }

        //Doing double jumps
        if (Controls.jumpInputDown(player) && player.airJumps < player.maxAirJumps)
        {
            player.audioManager.play("doublejump");
            player.airJumps++;
            player.selfBody.velocity = new Vector2(player.selfBody.velocity.x, player.jumpHeight);
            return;
        }

        //Doing air supers
        if (Controls.superInputDown(player) && player.meter > 20.0f)
        {
            player.ActionFsm.ChangeState(new DownSuperState(player, player.ActionFsm));
        }

        //Temporary measures until we get more animations.
        //if (movementInputVector.x != 0)
        //    player.anim.SetFloat("DirX", movementInputVector.x / Mathf.Abs(movementInputVector.x));
        //player.anim.SetFloat("DirY", Mathf.Ceil(Parameters.getVector(player.direction).y));
    }

    override public void FixedExecute()
    {
        float xVelocity = Mathf.Clamp(player.selfBody.velocity.x + movementInputVector.x * player.airDrift,
                                        -player.airMovementSpeed,
                                        player.airMovementSpeed);
        float yVelocity = player.selfBody.velocity.y;

        //Used for variable jump height
        if (!Controls.jumpInputHeld(player) && yVelocity > 0)
        {
            yVelocity = yVelocity * 0.9f;
        }

        player.selfBody.velocity = new Vector2(xVelocity, yVelocity);
    }

    override public void Exit()
    {
        player.airJumps = 0;
    }
}
