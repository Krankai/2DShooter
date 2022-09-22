using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class inherits from the UIelement class and handles updating the ability notice display
/// </summary>
public class AbilityNoticeDisplay : UIelement
{
    const string available = "Press T or Shift to activate thrusting";
    const string cooldown = "On cooldown";

    [Tooltip("The text UI to use for display")]
    public Text displayText = null;
    
    /// <summary>
    /// Description:
    /// Updates display for the usability of thrusting ability
    /// Inputs:
    /// none
    /// Returns:
    /// void (no return)
    /// </summary>
    public void DisplayAbilityNotice()
    {
        ThrustController thrustController = GameManager.instance.player.GetComponent<ThrustController>();
        if (displayText != null)
        {
            displayText.text = (thrustController.isUsable) ? available : cooldown;
        }
    }

        /// <summary>
    /// Description:
    /// Overides the virtual UpdateUI function and uses the DisplayLivesCount to update
    /// Inputs:
    /// none
    /// Returns:
    /// void (no return)
    /// </summary>
    public override void UpdateUI()
    {
        // This calls the base update UI function from the UIelement class
        base.UpdateUI();

        // The remaining code is only called for this sub-class of UIelement and not others
        DisplayAbilityNotice();
    }
}
