using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

    CursorLockMode wantedMode;

    public float speed = 5f;
    public float sensitivity = 5f;
    public float cameraRotationLimit = 80f;

    public Camera cam;
    public LayerMask mask;

    private float currentCameraRotationX = 0f;
    private Rigidbody rb;

    public float MaxTouchDistance;
    Ray ray;
    RaycastHit hit;


    void Start () {
        rb = GetComponent<Rigidbody>();
        wantedMode = CursorLockMode.Locked;
        SetCursorState();
    }

    void Update () {

        //Movement control
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveHorizontal = transform.right * moveX;
        Vector3 moveVertical = transform.forward * moveZ;

        Vector3 velocity = (moveHorizontal + moveVertical) * speed;

        rb.MovePosition(rb.position + (velocity* Time.deltaTime));

        //Camera control
        float rotY = Input.GetAxis("Mouse X");

        Vector3 rotation = new Vector3(0f, rotY, 0f) * sensitivity;

        float rotX = Input.GetAxis("Mouse Y");

        float cameraRotationX = rotX * sensitivity;

        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));

        if (cam != null) {
            currentCameraRotationX -= cameraRotationX;
            currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

            cam.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
        }

        // this is for (not)using your mouse again ingame
        if(Input.GetKeyDown(KeyCode.L)) {
            if(wantedMode == CursorLockMode.None) {
                wantedMode = CursorLockMode.Locked;
            } else {
                wantedMode = CursorLockMode.None;
            }
            SetCursorState();
        }
        // Interaction key
        if (Input.GetKey(KeyCode.E)) {
            ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, MaxTouchDistance)) {
                PuzzleLoader loader = hit.transform.parent.GetComponent<PuzzleLoader>();
                if (loader != null) {
                    loader.OnUsed();
                }
            }
        }
    }

    void SetCursorState() {
        Cursor.lockState = wantedMode;
        // Hide cursor when locking
        Cursor.visible = (CursorLockMode.Locked != wantedMode);
    }
}
