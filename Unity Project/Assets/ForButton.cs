using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ForButton : MonoBehaviour
{
    public TMP_Text collision_text;
    public int collision_status = 100;
   
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
            collision_status -= 1;
            collision_text.text = $"Collision {collision_status}";

        }
        
    }
}
