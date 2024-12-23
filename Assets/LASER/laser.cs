using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    [SerializeField] float Speed = 4f;
    [SerializeField] float LifeTime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, LifeTime); //self-destruct 2 sec 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Speed * Time.deltaTime, 0f, 0f); 
    }
    private void OnTriggerEnter2D(Collider2D collision) //destroy on collision
    {
        Destroy(gameObject);
    }
}
