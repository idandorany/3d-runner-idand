using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    public float walkSpeed = 3.0f;
    public float runSpeed = 6.0f;
    public float crouchSpeed = 1.5f;
    public float jumpForce = 5.0f;
    public float gravity = -9.81f;

    private CharacterController characterController;
    private Vector3 playerVelocity;
    private bool isGrounded;
    private bool isCrouching = false;
    private bool isMouseLocked = true;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        // Mouse kilidini açýp kapamak için "U" tuþunu kontrol et
        if (Input.GetKeyDown(KeyCode.U))
        {
            isMouseLocked = !isMouseLocked;

            if (isMouseLocked)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }

        // Kamera dönme kontrolü
        if (isMouseLocked)
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            Vector3 rotation = transform.rotation.eulerAngles;
            rotation.x -= mouseY;
            rotation.y += mouseX;
            transform.rotation = Quaternion.Euler(rotation);
        }

        // Yere temas kontrolü
        isGrounded = characterController.isGrounded;

        // Yatay ve dikey giriþleri al
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Hareket yönünü hesapla ve dünya koordinatlarýna dönüþtür
        Vector3 move = transform.right * horizontalInput + transform.forward * verticalInput;

        // Koþma ve çömelme iþlevselliði
        float moveSpeed = walkSpeed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = runSpeed;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isCrouching = !isCrouching;
            characterController.height = isCrouching ? 1.0f : 2.0f;
        }

        // Çömelme durumuna göre hareket hýzýný ayarla
        if (isCrouching)
        {
            moveSpeed = crouchSpeed;
        }

        // Hareket vektörünü hýz ve zamanla çarp
        move *= moveSpeed * Time.deltaTime;

        // Zýplama iþlevselliði
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            playerVelocity.y = Mathf.Sqrt(jumpForce * -2.0f * gravity);
        }

        // Gravitasyon uygula
        playerVelocity.y += gravity * Time.deltaTime;

        // Hareketi uygula
        characterController.Move(move + playerVelocity * Time.deltaTime);
    }
}
