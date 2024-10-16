using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    Vector2 direccion = Vector2.right;
    public GameObject gm;
    public Transform segmentoPrefab;
    List<Transform> tamaņoSerpiente = new List<Transform>();


    private void Start()
    {
        tamaņoSerpiente.Add(transform);
        Time.timeScale = 1.0f;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            direccion = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            direccion = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            direccion = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            direccion = Vector2.right;
        }


    }

    private void FixedUpdate()
    {

        for (int i = tamaņoSerpiente.Count - 1; i > 0; i--)
        {
            tamaņoSerpiente[i].position = tamaņoSerpiente[i - 1].position;
        }


        transform.position = new Vector3(Mathf.Round(transform.position.x) + direccion.x,
                                          Mathf.Round(transform.position.y) + direccion.y,
                                          0.0f);
    }
    void Reset()
    {
        for (int i = 1; i <tamaņoSerpiente.Count; i++)
        {
            Destroy(tamaņoSerpiente [i].gameObject);
        }
        tamaņoSerpiente.Clear();
        tamaņoSerpiente.Add(transform);
        transform.position = Vector3.zero;
    }


    void crecer()
    {
        Transform segmentoNuevo = Instantiate(segmentoPrefab);
        segmentoNuevo.position = tamaņoSerpiente[tamaņoSerpiente.Count-1].position;
        tamaņoSerpiente.Add(segmentoNuevo);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstaculo"))
        {
            Reset();
            gm.GetComponent<comida>().randompos();
            
        }

        if (collision.CompareTag("Comida"))
        {
            crecer();
        }

    }
}
