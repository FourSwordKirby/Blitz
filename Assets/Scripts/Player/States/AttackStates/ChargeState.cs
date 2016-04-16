using UnityEngine;
using System.Collections;

public class ChargeState : State<Player>
{
    private Player player;

    private float speed = 10.0f;
    private Vector2 direction;
    private float minimumActiveTime = 0.1f;
    private float maximumActiveTime = 0.4f;
    private float activeTimer = 0.0f;

    public ChargeState(Player playerInstance, StateMachine<Player> fsm) : base(playerInstance, fsm)
    {
        player = playerInstance;
    }

    override public void Enter()
    {
        player.anim.SetBool("Charge", true);
        player.chargeTrail.gameObject.SetActive(true);
        player.hitboxManager.activateHitBox("ChargeHitbox");
        direction = Controls.getDirection(player);

        player.anim.SetFloat("DirX", direction.x);
    }

    override public void Execute()
    {
        activeTimer += Time.deltaTime;
        if (activeTimer > minimumActiveTime)
        {
            if (!Controls.attackInputHeld(player) || activeTimer > maximumActiveTime)
            {
                player.ActionFsm.ChangeState(new IdleState(player, player.ActionFsm));
            }
        }
    }

    override public void FixedExecute()
    {
        player.selfBody.velocity = direction * speed;
    }

    override public void Exit()
    {
        player.anim.SetBool("Charge", false);
        player.chargeTrail.gameObject.SetActive(false);
        player.hitboxManager.deactivateHitBox("ChargeHitbox");
    }
}
