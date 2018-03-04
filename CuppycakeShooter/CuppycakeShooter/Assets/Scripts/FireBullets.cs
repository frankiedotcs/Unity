using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullets : MonoBehaviour
{

    Vector2 mouseLook;
    Vector2 smoothV;

    public AudioClip shoot;
    public Rigidbody bulletType;
    public Rigidbody pigAmmo;
    public Rigidbody cakeAmmo;
    public Rigidbody beerAmmo;

    public float force = 7.0f;
    public ForceMode forceMode;
    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;


    GameObject player;

    // Use this for initialization
    void Start()
    {
        player = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        mouseLook += smoothV;

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, player.transform.up);

    }




    protected void Fire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<AudioSource>().PlayOneShot(shoot);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Quaternion rotation = Quaternion.LookRotation(ray.direction);

            Vector3 spawnPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y, GetComponent<Camera>().nearClipPlane));


            Rigidbody instance = Instantiate(bulletType, transform.position, rotation) as Rigidbody;
            instance.AddForce(ray.direction * force, forceMode);

        }
    }

    protected void FirePigBullets()
    {
        if (Input.GetMouseButtonDown(1))
        {
            GetComponent<AudioSource>().PlayOneShot(shoot);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Quaternion rotation = Quaternion.LookRotation(ray.direction);

            Vector3 spawnPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y, GetComponent<Camera>().nearClipPlane));


            Rigidbody instance = Instantiate(pigAmmo, transform.position, rotation) as Rigidbody;
            instance.AddForce(ray.direction * force, forceMode);

        }
    }

    protected void FireCakeBullets()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            GetComponent<AudioSource>().PlayOneShot(shoot);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Quaternion rotation = Quaternion.LookRotation(ray.direction);

            Vector3 spawnPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y, GetComponent<Camera>().nearClipPlane));


            Rigidbody instance = Instantiate(cakeAmmo, transform.position, rotation) as Rigidbody;
            instance.AddForce(ray.direction * force, forceMode);

        }
    }

    protected void FireBeerBullets()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            GetComponent<AudioSource>().PlayOneShot(shoot);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Quaternion rotation = Quaternion.LookRotation(ray.direction);

            Vector3 spawnPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y, GetComponent<Camera>().nearClipPlane));


            Rigidbody instance = Instantiate(beerAmmo, transform.position, rotation) as Rigidbody;
            instance.AddForce(ray.direction * force, forceMode);

        }
    }
}