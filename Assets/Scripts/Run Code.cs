using UnityEngine;

public class RunCode : MonoBehaviour
{
    public float maxStamina = 100f;
    public float staminaDecreaseRate = 20f;
    public float staminaIncreaseRate = 10f;
    public float minStaminaToRun = 10f;

    private float currentStamina;

    private void Start()
    {
        currentStamina = maxStamina;
    }

    private void Update()
    {
        // Decrease stamina while left shift is held down
        if (Input.GetKey(KeyCode.LeftShift) && currentStamina > 0f)
        {
            currentStamina -= staminaDecreaseRate * Time.deltaTime;
            currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);
        }
        // Increase stamina when left shift is released
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            currentStamina += staminaIncreaseRate * Time.deltaTime;
            currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);
        }

        // Check if the player has enough stamina to run
        bool canRun = currentStamina >= minStaminaToRun;

        // Run when both left shift is pressed and stamina is sufficient
        if (Input.GetKey(KeyCode.LeftShift) && canRun)
        {
            // Run code here
            
        }
    }
}
