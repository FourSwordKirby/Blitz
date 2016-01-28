using UnityEngine;
using System.Collections;

public class Controls {

    public static Vector2 getDirection(Player player)
    {
        float xAxis = 0;
        float yAxis = 0;

        if (GameManager.Players.IndexOf(player) == 0)
        {
            xAxis = Input.GetAxis("P1 Horizontal");
            yAxis = Input.GetAxis("P1 Vertical");
        }
        else if (GameManager.Players.IndexOf(player) == 1)
        {
            xAxis = Input.GetAxis("P2 Horizontal");
            yAxis = Input.GetAxis("P2 Vertical");
        }
        else if (GameManager.Players.IndexOf(player) == 2)
        {
            xAxis = Input.GetAxis("P3 Horizontal");
            yAxis = Input.GetAxis("P3 Vertical");
        }
        else if (GameManager.Players.IndexOf(player) == 3)
        {
            xAxis = Input.GetAxis("P4 Horizontal");
            yAxis = Input.GetAxis("P4 Vertical");
        }
        return new Vector2(xAxis, yAxis);
    }

    public static Parameters.InputDirection getInputDirection(Player player)
    {
        return Parameters.vectorToDirection(getDirection(player));
    }

    public static bool jumpInputDown(Player player)
    {
        if (GameManager.Players.IndexOf(player) == 0)
            return Input.GetButtonDown("P1 Jump");
        else if (GameManager.Players.IndexOf(player) == 1)
            return Input.GetButtonDown("P2 Jump");
        else if (GameManager.Players.IndexOf(player) == 2)
            return Input.GetButtonDown("P3 Jump");
        else if (GameManager.Players.IndexOf(player) == 3)
            return Input.GetButtonDown("P4 Jump");
        else
            return false;
    }

    public static bool attackInputDown(Player player)
    {
        if (GameManager.Players.IndexOf(player) == 0)
            return Input.GetButtonDown("P1 Attack");
        else if (GameManager.Players.IndexOf(player) == 1)
            return Input.GetButtonDown("P2 Attack");
        else if (GameManager.Players.IndexOf(player) == 2)
            return Input.GetButtonDown("P3 Attack");
        else if (GameManager.Players.IndexOf(player) == 3)
            return Input.GetButtonDown("P4 Attack");
        else
            return false;
    }

    public static bool specialInputDown(Player player)
    {
        if (GameManager.Players.IndexOf(player) == 0)
            return Input.GetButtonDown("P1 Special");
        else if (GameManager.Players.IndexOf(player) == 1)
            return Input.GetButtonDown("P2 Special");
        else if (GameManager.Players.IndexOf(player) == 2)
            return Input.GetButtonDown("P3 Special");
        else if (GameManager.Players.IndexOf(player) == 3)
            return Input.GetButtonDown("P4 Special");
        else
            return false;
    }

    public static bool shieldInputDown(Player player)
    {
        if (GameManager.Players.IndexOf(player) == 0)
            return Input.GetButtonDown("P1 Shield");
        else if (GameManager.Players.IndexOf(player) == 1)
            return Input.GetButtonDown("P2 Shield");
        else if (GameManager.Players.IndexOf(player) == 2)
            return Input.GetButtonDown("P3 Shield");
        else if (GameManager.Players.IndexOf(player) == 3)
            return Input.GetButtonDown("P4 Shield");
        else
            return false;
    }

    public static bool enhanceInputDown(Player player)
    {
        if (GameManager.Players.IndexOf(player) == 0)
            return Input.GetButtonDown("P1 Enhance");
        else if (GameManager.Players.IndexOf(player) == 1)
            return Input.GetButtonDown("P2 Enhance");
        else if (GameManager.Players.IndexOf(player) == 2)
            return Input.GetButtonDown("P3 Enhance");
        else if (GameManager.Players.IndexOf(player) == 3)
            return Input.GetButtonDown("P4 Enhance");
        else
            return false;
    }

    public static bool superInputDown(Player player)
    {
        if (GameManager.Players.IndexOf(player) == 0)
            return Input.GetButtonDown("P1 Super");
        else if (GameManager.Players.IndexOf(player) == 1)
            return Input.GetButtonDown("P2 Super");
        else if (GameManager.Players.IndexOf(player) == 2)
            return Input.GetButtonDown("P3 Super");
        else if (GameManager.Players.IndexOf(player) == 3)
            return Input.GetButtonDown("P4 Super");
        else
            return false;
    }

    public static bool pauseInputDown(Player player)
    {
        return Input.GetButtonDown("Pause");
    }


    public static bool jumpInputHeld(Player player)
    {
        if (GameManager.Players.IndexOf(player) == 0)
            return Input.GetButton("P1 Jump");
        else if (GameManager.Players.IndexOf(player) == 1)
            return Input.GetButton("P2 Jump");
        else if (GameManager.Players.IndexOf(player) == 2)
            return Input.GetButton("P3 Jump");
        else if (GameManager.Players.IndexOf(player) == 3)
            return Input.GetButton("P4 Jump");
        else
            return false;
    }

    public static bool attackInputHeld(Player player)
    {
        if (GameManager.Players.IndexOf(player) == 0)
            return Input.GetButton("P1 Attack");
        else if (GameManager.Players.IndexOf(player) == 1)
            return Input.GetButton("P2 Attack");
        else if (GameManager.Players.IndexOf(player) == 2)
            return Input.GetButton("P3 Attack");
        else if (GameManager.Players.IndexOf(player) == 3)
            return Input.GetButton("P4 Attack");
        else
            return false;
    }

    public static bool specialInputHeld(Player player)
    {
        if (GameManager.Players.IndexOf(player) == 0)
            return Input.GetButton("P1 Special");
        else if (GameManager.Players.IndexOf(player) == 1)
            return Input.GetButton("P2 Special");
        else if (GameManager.Players.IndexOf(player) == 2)
            return Input.GetButton("P3 Special");
        else if (GameManager.Players.IndexOf(player) == 3)
            return Input.GetButton("P4 Special");
        else
            return false;
    }

    public static bool shieldInputHeld(Player player)
    {
        if (GameManager.Players.IndexOf(player) == 0)
            return Input.GetButton("P1 Shield");
        else if (GameManager.Players.IndexOf(player) == 1)
            return Input.GetButton("P2 Shield");
        else if (GameManager.Players.IndexOf(player) == 2)
            return Input.GetButton("P3 Shield");
        else if (GameManager.Players.IndexOf(player) == 3)
            return Input.GetButton("P4 Shield");
        else
            return false;
    }

    public static bool enhanceInputHeld(Player player)
    {
        if (GameManager.Players.IndexOf(player) == 0)
            return Input.GetButton("P1 Enhance");
        else if (GameManager.Players.IndexOf(player) == 1)
            return Input.GetButton("P2 Enhance");
        else if (GameManager.Players.IndexOf(player) == 2)
            return Input.GetButton("P3 Enhance");
        else if (GameManager.Players.IndexOf(player) == 3)
            return Input.GetButton("P4 Enhance");
        else
            return false;
    }

    public static bool superInputHeld(Player player)
    {
        if (GameManager.Players.IndexOf(player) == 0)
            return Input.GetButton("P1 Super");
        else if (GameManager.Players.IndexOf(player) == 1)
            return Input.GetButton("P2 Super");
        else if (GameManager.Players.IndexOf(player) == 2)
            return Input.GetButton("P3 Super");
        else if (GameManager.Players.IndexOf(player) == 3)
            return Input.GetButton("P4 Super");
        else
            return false;
    }

    public static bool pauseInputHeld(Player player)
    {
        return Input.GetButton("Pause");
    }
}
