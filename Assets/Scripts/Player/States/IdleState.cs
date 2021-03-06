﻿using UnityEngine;
using System.Collections;

public class IdleState : State<Player> {

    private Player player;

    public IdleState(Player playerInstance, StateMachine<Player> fsm)
        : base(playerInstance, fsm)
    {
        player = playerInstance;
    }

    override public void Enter()
    {
        //Used to slow you down as you land
        player.selfBody.velocity = 0.5f * player.selfBody.velocity;
        player.anim.SetFloat("MoveSpeed", 0.0f);

        player.anim.SetFloat("DirX", Parameters.VectorToDir(player.direction).x);
    }

    override public void Execute()
    {
        Vector2 movementInputVector = Controls.getDirection(player);
        //Might want to change this stuff later to include transition states
        //Moving
        if (movementInputVector.x != 0)
        {
            player.direction = Parameters.vectorToDirection(movementInputVector);

            player.ActionFsm.ChangeState(new MovementState(player, player.ActionFsm));
            return;
        }

        //Jumping
        if (Controls.jumpInputDown(player))
        {
            player.ActionFsm.ChangeState(new AirState(player, player.ActionFsm));
            return;
        }

        //falling through platform
        //This needs to be fixed to not just shove me in an air state. It will kick my ass later
        if (Controls.getDirection(player).y < -Controls.FALL_THROUGH_THRESHOLD)
        {

            player.grounded = false;
            player.environmentCollisionBox.fallThrough();
            player.ActionFsm.ChangeState(new AirState(player, player.ActionFsm));
            return;
        }

        if (Controls.shieldInputDown(player))
        {
            player.ActionFsm.ChangeState(new ShieldState(player, player.ActionFsm));
        }
    }

    override public void FixedExecute(){    }

    override public void Exit(){    }
}
