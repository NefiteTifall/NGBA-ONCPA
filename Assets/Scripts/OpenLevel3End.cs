using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLevel3End : MonoBehaviour
{
    // Leviers à activer
    public GameObject lever1;
    public GameObject lever2;
    public GameObject lever3;
    public GameObject lever4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(lever1.GetComponent<MoveLever>().leverActivated);
        if (lever1.GetComponent<MoveLever>().leverActivated && lever2.GetComponent<MoveLever>().leverActivated && !lever3.GetComponent<MoveLever>().leverActivated && lever4.GetComponent<MoveLever>().leverActivated){
            // Désactive le mur
            gameObject.SetActive(false);
        } 
    }
}
