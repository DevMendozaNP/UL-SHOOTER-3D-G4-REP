using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private Vector3 direction = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    
    private CharacterController characterController;
    private Transform myCamera;
    [SerializeField]
    private GameObject HealthUI;

    [SerializeField]
    private float MovementSpeed = 3f;

    [SerializeField]
    private float RotationSpeedHorizontal = 2f;
    [SerializeField]
    private float RotationSpeedVertical = 2f;

    [SerializeField]
    private float enemyDamage = 25f;
    [SerializeField]
    private float iframeDuration = 2f;
    private bool isInvincible = false;

    public GameObject[] weapons;
    private int currentWeapon = 0;
    [SerializeField]
    private GameObject weaponUI;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        myCamera = transform.Find("Camera");
    }

    private void Update()
    {
        // Movimiento
        characterController.Move(
            transform.forward * direction.normalized.z * Time.deltaTime * MovementSpeed
            + transform.right * direction.normalized.x * Time.deltaTime * MovementSpeed
        );

        // Rotacion horizontal
        transform.Rotate(
            0f,
            rotation.y * Time.deltaTime * RotationSpeedHorizontal,
            0f
        );

        // Rotacion vertical (camara)
        myCamera.Rotate(
            rotation.x * Time.deltaTime * RotationSpeedVertical, //TODO: Clamp
            0f,
            0f
        );

        //Cambio de arma
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // Oculta el arma actual
            weapons[currentWeapon].SetActive(false);

            // Cambia al siguiente arma
            currentWeapon = (currentWeapon + 1) % weapons.Length;
            myCamera.GetComponent<PlayerFire>().shotgunActivator();
            weaponUI.GetComponent<PlayerWeapon>().iconActivator();

            // Muestra el nuevo arma
            weapons[currentWeapon].SetActive(true);
        }

        //recarga
        if (Input.GetKeyDown(KeyCode.R))
        {
            myCamera.GetComponent<PlayerFire>().bulletRecharge();
        }
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnMove(InputValue value)
    {
        var data = value.Get<Vector2>();
        direction = new Vector3(
            data.x,
            0f,
            data.y            
        );
    }

    private void OnFire(InputValue value)
    {
        if(value.isPressed)
        {
            myCamera.GetComponent<PlayerFire>().Fire();
        }
    }

    private void OnLook(InputValue value)
    {
        var data = value.Get<Vector2>();
        rotation = new Vector3(
            data.y, // rotacion vertical (sobre eje X)
            data.x, // rotacion horizontal (sobre eje Y)
            0f     
        );
    }

    //Le avisa al manager que hubo daño
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "Enemy" && isInvincible == false)
        {
            HealthUI.GetComponent<PlayerHealth>().damageTaken(enemyDamage);
            StartCoroutine(IFrames());
        }
    }

    private IEnumerator IFrames()
    {
        isInvincible = true;
        yield return new WaitForSeconds(iframeDuration);
        isInvincible = false;
    }


}
