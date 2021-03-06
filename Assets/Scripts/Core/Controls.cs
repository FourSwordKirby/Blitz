﻿using UnityEngine;
using System.Collections;

public class Controls {

    /*These constants refer to specific thresholds for reading in inputs
     * For example, the constant FALL_THROUGH_THRESHOLD denotes the threshold 
     * between crouching on a platform and falling through the platform
     */
    public const float FALL_THROUGH_THRESHOLD = 0.5f;
    public const float axisThreshold = 0.5f;
    public const float keyboardScaling = 2.0f;

    public static Vector2 getDirection(Player player)
    {
        float xAxis = 0;
        float yAxis = 0;

        if (GameManager.Players.IndexOf(player) == 0)
        {
            if (Mathf.Abs(Input.GetAxis("P1 Horizontal")) > Mathf.Abs(Input.GetAxis("P1 Keyboard Horizontal")))
            {
                xAxis = Input.GetAxis("P1 Horizontal");

                if (Mathf.Abs(xAxis) < axisThreshold)
                    xAxis = 0;
            }
            else
                xAxis = Mathf.Clamp(keyboardScaling * Input.GetAxis("P1 Keyboard Horizontal"), -1, 1);
            if (Mathf.Abs(Input.GetAxis("P1 Vertical")) > Mathf.Abs(Input.GetAxis("P1 Keyboard Vertical")))
            {
                yAxis = Input.GetAxis("P1 Vertical");

                if (Mathf.Abs(yAxis) < axisThreshold)
                    yAxis = 0;
            }
            else
                yAxis = Mathf.Clamp(keyboardScaling * Input.GetAxis("P1 Keyboard Vertical"), -1, 1);
        }
        else if (GameManager.Players.IndexOf(player) == 1)
        {
            if (Mathf.Abs(Input.GetAxis("P2 Horizontal")) > Mathf.Abs(Input.GetAxis("P2 Keyboard Horizontal")))
            {
                xAxis = Input.GetAxis("P2 Horizontal");

                if (Mathf.Abs(xAxis) < axisThreshold)
                    xAxis = 0;
            }
            else
                xAxis = Mathf.Clamp(keyboardScaling * Input.GetAxis("P2 Keyboard Horizontal"), -1, 1);
            if (Mathf.Abs(Input.GetAxis("P2 Vertical")) > Mathf.Abs(Input.GetAxis("P2 Keyboard Vertical")))
            {
                yAxis = Input.GetAxis("P2 Vertical");

                if (Mathf.Abs(yAxis) < axisThreshold)
                    yAxis = 0;
            }
            else
                yAxis = Mathf.Clamp(keyboardScaling * Input.GetAxis("P2 Keyboard Vertical"), -1, 1);
        }
        /* Disabled because no 4 player support in the foreseeable future (hard for people to get a gc adapter, arcade cabinet doesn't support, etc)
        else if (GameManager.Players.IndexOf(player) == 2)
        {
            if (Mathf.Abs(Input.GetAxis("P3 Horizontal")) > Mathf.Abs(Input.GetAxis("P3 Keyboard Horizontal")))
                xAxis = Input.GetAxis("P3 Horizontal");
            else
                xAxis = Input.GetAxis("P3 Keyboard Horizontal");
            if (Mathf.Abs(Input.GetAxis("P3 Vertical")) > Mathf.Abs(Input.GetAxis("P3 Keyboard Vertical")))
                yAxis = Input.GetAxis("P3 Vertical");
            else
                yAxis = Input.GetAxis("P3 Keyboard Vertical");
        }
        else if (GameManager.Players.IndexOf(player) == 3)
        {
            if (Mathf.Abs(Input.GetAxis("P4 Horizontal")) > Mathf.Abs(Input.GetAxis("P4 Keyboard Horizontal")))
                xAxis = Input.GetAxis("P4 Horizontal");
            else
                xAxis = Input.GetAxis("P4 Keyboard Horizontal");
            if (Mathf.Abs(Input.GetAxis("P4 Vertical")) > Mathf.Abs(Input.GetAxis("P4 Keyboard Vertical")))
                yAxis = Input.GetAxis("P4 Vertical");
            else
                yAxis = Input.GetAxis("P4 Keyboard Vertical");
        }
         * */
        Vector2 inputVector = new Vector2(xAxis, yAxis);
        return inputVector;
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
