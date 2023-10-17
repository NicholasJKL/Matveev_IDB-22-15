using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ForButton : MonoBehaviour
{
    public TMP_Text collision_text;
    int collision_status = 100;
    public Rigidbody rb;
    float bounceForce = 16f;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    public void hide_unhide()
    {
        if (this.gameObject.activeSelf)
            this.gameObject.SetActive(false);
        else
            this.gameObject.SetActive(true);



    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Cylinder") 
        {

            Vector3 direction = (transform.position - collision.transform.position).normalized;
            Debug.Log(transform.position);
            Debug.Log(collision.transform.position);
            rb.AddForce(direction * bounceForce, ForceMode.Impulse);
            collision_status -= 1;
            collision_text.text = $"Collision {collision_status}";

        }
        
    }
}
