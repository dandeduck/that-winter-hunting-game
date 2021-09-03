using UnityEngine;

public abstract class Moveable : MonoBehaviour
{
    public CharacterController controller;
    public float acceleration;
    public float decceleration;

    private float currentSpeed;
    private Vector3 currentDirection;
    private Vector3 prevDirection;
    private bool isStopping;
    
    private void Start()
    {
        currentSpeed = 0;
        prevDirection = transform.position;   
        isStopping = false;
    }

    private void Update()
    {
        currentDirection = MoveDirection();

        if (currentDirection.magnitude >= 0.1f)
        {
            isStopping = false;
            prevDirection = currentDirection;
            currentSpeed = Mathf.Min(MaxSpeed(), currentSpeed+acceleration);
            controller.Move(currentDirection * currentSpeed * Time.deltaTime);
        }
        else
        {
            isStopping = true;
            currentSpeed = Mathf.Max(0, currentSpeed-decceleration);
            controller.Move(prevDirection * currentSpeed * Time.deltaTime);
        }
    }

    public Vector3 GetVelocity()
    {
        return currentDirection * currentSpeed;
    }

    public bool IsStopping()
    {
        return isStopping;
    }

    protected abstract Vector3 MoveDirection();
    protected abstract float MaxSpeed();
}