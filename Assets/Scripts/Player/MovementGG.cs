using System.Collections;
using UnityEngine;

public class MovementGG : MonoBehaviour
{
    // Скорость робота
    [SerializeField] private float speed;
    [SerializeField] private float _run;
    [SerializeField] private float _walk;


    // Потребления енергии 
    [SerializeField] private float jump = 2;
    [SerializeField] private float walk = 1.5f;
    [SerializeField] private float run = 2.5f;
    [SerializeField] private float sprint = 3;
    [SerializeField] private float goose = 2;
    [SerializeField] private float idle = 1;

    // Енергия
    [SerializeField] private float maxEnergy = 80;
    [SerializeField] public float playerEnergy = 100;

    // Енергия батарейки
    [SerializeField] private float batteryEnergy = 20;


    private float defoltSpeed;
    public bool Battery = false; // Проверка есть ли батарейка
    private bool isWalking = false; // Проверка на переключения режима бега на ходьбу

    public CharacterController controller; // Ссылка на контроллер компонента
    public float Force = 3; //сила движения перса
    public float smoothTime = 0.2f;
    float smoothVelicity;
    public Animator animator;
    public Transform firstCamera;
    private bool isAltPressed = false; // Флаг, указывающий, удерживается ли в данный момент кнопка ALT


   
    void Start()
    {
        defoltSpeed = speed;
       

        // Скрываем курсор мыши и блокируем его в центре экрана
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        StartCoroutine(ToDamage());
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.X))
        {
            isWalking = !isWalking;
        }


        // Проверяем, удерживается ли кнопка ALT в данный момент
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            isAltPressed = true;


        }
        else // Если кнопка ALT не удерживается, блокируем курсор мыши обратно
        {
            isAltPressed = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

        }

        // Если кнопка ALT удерживается, выходим из функции, чтобы персонаж не двигался
        if (isAltPressed)
            return;

        float horizontal = Input.GetAxisRaw("Horizontal");//бинд по горизонтали
        float vertical = Input.GetAxisRaw("Vertical");//бинд по вертикали
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized; //что бы при нажатии 2х кнопок, скорость не скалывдалась

        if(direction.magnitude >= 0.1f)
        {
            float rotationAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + firstCamera.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0f, rotationAngle, 0f);
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationAngle, ref smoothVelicity, smoothTime);
            Vector3 move = Quaternion.Euler(0f, rotationAngle, 0f) * Vector3.forward;

            controller.Move(move.normalized * Force * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = run;
                animator.SetBool("sprint", true);
            }
            else if (Input.GetKey(KeyCode.X))
            {
                if (animator.GetBool("walk") == false)
                {
                    
                    animator.SetBool("walk", true);
                    speed = walk;
                }
                else
                {
                    animator.SetBool("walk", false);
                
                }
            }
        else
            {
            if (animator.GetBool("walk") == false)
            {
                speed = defoltSpeed;
            }
                  
                animator.SetBool("sprint", false);
            }

            if (Input.GetKey(KeyCode.LeftControl))
            {
                animator.SetBool("goose", true);
            }
            else
            {
                animator.SetBool("goose", false);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetTrigger("Jump");
            }

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                animator.SetBool("run", true);
            }
            else
            {
                animator.SetBool("run", false);
            }

            if (Input.GetKey(KeyCode.R))
            {
             if (Battery == true)
             {
                if (playerEnergy < maxEnergy)
                {
                    Battery = false;
                    playerEnergy += batteryEnergy;
                }
             }
            }
    }
    private IEnumerator ToDamage()
    {
        while (playerEnergy > 0)
        {
            Debug.Log("Урон");
            playerEnergy -= idle;

            float energyConsumption = isWalking ? walk : run;

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
            {
                playerEnergy -= energyConsumption;
                Debug.Log(isWalking ? "Ходьба" : "Бег");
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                playerEnergy -= sprint;
            }
            if (Input.GetKey(KeyCode.Space))
            {
                playerEnergy -= jump;
            }
            if (Input.GetKey(KeyCode.LeftControl))
            {
                playerEnergy -= goose;
            }

            yield return new WaitForSeconds(1.0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Battery"))
        {
            Battery = true;
            
            
                Destroy(other.gameObject);
            
        }
    }
}

