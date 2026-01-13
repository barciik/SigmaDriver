using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public float limitX;
    public float moveRate;

    Vector3 mousePos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Menu")
        {
            GetComponent<Animator>().Play("Idle");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        TouchInput();
    }

    void Run(){

        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    void TouchInput(){

        if (Input.GetMouseButton(0))
        {
            mousePos = Input.mousePosition;
            mousePos.z = 5f;

            mousePos = Camera.main.ScreenToWorldPoint(mousePos);



            Vector3 newPosition = transform.position;
            newPosition.x = mousePos.x;

            transform.position = Vector3.Lerp(transform.position, newPosition, moveRate);

            
            float clampedX = Mathf.Clamp(transform.position.x, -limitX, limitX);

            Vector3 limitedPosition = transform.position;
            limitedPosition.x = clampedX;

            transform.position = limitedPosition;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            //GameOver
            SceneManager.LoadScene("Menu");
        }
    }



}
