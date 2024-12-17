using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float controlSpeed = 50f;
    [SerializeField] private float xClampRange;
    [SerializeField] private float yClampRange;

    [SerializeField] private float controlRollFactor;
    [SerializeField] private float controlPitchFactor;
    [SerializeField] private float controlYawFactor;



    private Vector2 movement;
    
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessTranslation()
    {
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xClampRange, xClampRange);
        
        float yOffset = movement.y * controlSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yClampRange, yClampRange);
        
        transform.localPosition = new Vector3(clampedXPos, clampedYPos, 0f);
    }
    
    private void ProcessRotation()
    {
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, -controlRollFactor * movement.x);
        transform.localRotation = targetRotation;
    }
    
    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }
}
