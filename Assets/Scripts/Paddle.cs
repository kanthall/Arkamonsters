using UnityEngine;

public class Paddle : MonoBehaviour
{

    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    [SerializeField] float screenWidthInUnits = 16f;

    /*private void Awake()
    {
        transform.position = new Vector2(0f, 0.64f);
    }*/

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        float mousePositionInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;

        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);

        paddlePosition.x = Mathf.Clamp(mousePositionInUnits, minX, maxX);
        transform.position = paddlePosition;
    }

    public void ResetPaddlePosition()
    {
        transform.position = new Vector2(8f, 0.64f);
    }
}
