using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playercontroller : MonoBehaviour {

    public static Playercontroller P;
    [SerializeField]
    private float movimentSpeed;
    [HideInInspector] public LifeScript life;
    public static bool plane; //false hell, true limbo


    private void CheckDeath()
    {
        if (life.health <= 0) SceneManager.LoadScene("Game over");
    }

	void Start ()
    {
        P = this;
        life = GetComponent<LifeScript>();
	}
	
	void Update () {
        HandleMovementInput();
        HandleRotationInput();
        HandleShootInput();

        HandleChangePlane();

        CheckDeath();
    }

    void HandleMovementInput ()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical);
        transform.Translate(movement * movimentSpeed * Time.deltaTime, Space.World);
    }

    void HandleRotationInput ()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }
    }

    void HandleShootInput ()
    {
        if (Input.GetButton("Fire1"))
        {
            playergun.Instance.Shoot();
        }
    }

    private void HandleChangePlane ()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            plane = true;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            plane = false;
        }
    }

}
