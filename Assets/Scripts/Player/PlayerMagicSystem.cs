using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagicSystem : MonoBehaviour
{
    public Magic Magic;
    public PlayerMovements PlayerMovements;
    private Camera mainCamera;
    [SerializeField] private Vector3 mousePosition;
    [SerializeField] private Transform magicSpaw;
    private bool castingMagic;
    private float timer;
    private float timerBeteweenCasting;


    void Awake()
    {
        PlayerMovements = GetComponent<PlayerMovements>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        MagicSpawPosition();

        if (!castingMagic)
        {
            timer += Time.deltaTime;
            if (timer > timerBeteweenCasting)
            {
                castingMagic = true;
                timer = 0;
            }
        }

        // Player Magic Attack
        if (Input.GetButtonDown("Fire1") && castingMagic) CastSpell();
    }

    void MagicSpawPosition()
    {
        mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePosition - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

    }

    void CastSpell()
    {
        castingMagic = false;
        GameObject newMagic = Instantiate(Magic.gameObject, magicSpaw.transform.position, Quaternion.identity);
        Vector3 direction = mousePosition - transform.position;
        newMagic.GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x, direction.y).normalized * Magic.MagicScriptableObject.MagicSpeed;
        Debug.Log("Magic Casted " + Magic.MagicScriptableObject.MagicName);

    }
}
