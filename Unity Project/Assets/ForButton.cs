using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ForButton : MonoBehaviour
{
    public TMP_Text collision_text;
    int collision_status = 100;
    float bounceForce = 16f;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    public void hide_unhide()
    {
        if (gameObject.activeSelf)
            gameObject.SetActive(false);
        else
            gameObject.SetActive(true);



    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Cylinder") 
        {

            Vector3 direction = (gameObject.transform.position - collision.gameObject.transform.position).normalized;
            gameObject.GetComponent<Rigidbody>().AddForce(direction * bounceForce, ForceMode.Impulse);
            collision_status -= 1;
            collision_text.text = $"Collision {collision_status}";

        }
        
    }
}
