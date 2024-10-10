using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comida : MonoBehaviour
{
    public BoxCollider2D gridarea;
    
    // Start is called before the first frame update
    void Start()
    {
        randompos();
    }

  public void randompos()
    {
        Bounds limites = gridarea.bounds;

        float x = Random.Range(limites.min.x, limites.max.x);
        float y = Random.Range(limites.min.y, limites.max.y);

        transform.position = new Vector3(Mathf.Round(x), Mathf.Round (y), 0); 

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("snake"))
        {
            randompos();
        }

    }

    }




