using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// This class controls thrusting ability of player, including the corresponding "thrusting" sprite animation
/// </summary>
public class ThrustController : MonoBehaviour
{
    [Tooltip("Prefab to spawn when thrusting effect is on")]
    public GameObject thrustEffect;

    [Tooltip("Position at which thrusting effect will be spawned")]
    public Transform thrustPosition;

    [Tooltip("Speed multiplier applied when thrusting effect is on")]
    public float thrustMultiplier = 2.0f;

    [Tooltip("Duration the thrusting multiplier will be in effect")]
    public float thrustDuration = 3.0f;

    // Indicate whether thrusting ability can be used immediately or still in cooldown
    private bool isOn = true;

    // Getter/Setter for available status of thrusting ability
    public bool isUsable
    {
        get { return isOn; }
        set { isOn = value; }
    }

    /// <summary>
    /// Description:
    /// This function applies thrusting effect onto player object, and
    /// displays the corresponding thrusting sprite animation
    /// Inputs: 
    /// none
    /// Returns: 
    /// void (no return)
    /// </summary>
    public void ApplyThrust()
    {
        if (!isUsable) return;

        Transform playerTransform = GameManager.instance.player.transform;
        if (thrustEffect != null)
        {
            Instantiate(thrustEffect, thrustPosition.position, playerTransform.rotation, playerTransform);
        }

        Controller playerController = GameManager.instance.player.GetComponent<Controller>();
        playerController.AccelerateSpeed(thrustMultiplier, thrustDuration);

        isUsable = false;
        Invoke("ResetStatus", thrustDuration);
    }

    /// <summary>
    /// Description:
    /// This function reset the availability of thrusting ability
    /// displays the corresponding thrusting sprite animation
    /// Inputs: 
    /// none
    /// Returns: 
    /// void (no return)
    /// </summary>
    private void ResetStatus()
    {
        isUsable = true;
        GameManager.UpdateUIElements();
    }

    private void Update()
    {
        bool isShiftPressThisFrame = Keyboard.current.FindKeyOnCurrentKeyboardLayout("right shift").wasPressedThisFrame || Keyboard.current.FindKeyOnCurrentKeyboardLayout("shift").wasPressedThisFrame;
        if (Keyboard.current.FindKeyOnCurrentKeyboardLayout("t").wasPressedThisFrame || isShiftPressThisFrame)
        {
            ApplyThrust();
            GameManager.UpdateUIElements();
        }
    }

    private void Start()
    {
        isUsable = true;
    }
}
