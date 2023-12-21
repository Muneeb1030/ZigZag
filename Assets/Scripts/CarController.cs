using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private bool isMovingLeft = false;
    private bool isFirstInput = true;

    void Update()
    {
        if(GameManager.instance.isGameStarted)
        {
            Move();
            checkInput();
        }
    }

    private void checkInput()
    {
        if(isFirstInput)
        {
            isFirstInput = false;
            return;
        }
        if(Input.GetMouseButtonDown(0))
        {
            isMovingLeft = !isMovingLeft;
            transform.rotation = Quaternion.Euler(0f, isMovingLeft ? 90f : 0f, 0f);
        }
        if (transform.position.y <= -2)
            GameManager.instance.GameOver();
    }

    private void Move()
    {
        transform.position += transform.forward*moveSpeed*Time.deltaTime;
    }
}
