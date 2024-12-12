using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VIEWGREEN : MonoBehaviour
{
    public int index;
    public GameObject Model;
    public GameObject Cloth;
    //public Color color1, color2;
    public RawImage scale, model, female;
    private bool fema = false;
    private int femint = 3;
    // Start is called before the first frame update
    void Start()
    {
        index=0;
        model.color= Color.green;
        female.color= Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("ViewM"))
        {
            if (Model.activeSelf)
            {
                Model.SetActive(false);
                model.color = Color.red;

            }
            else
            {
                Model.SetActive(true);
                model.color = Color.green;
            }
        }

        if (Input.GetButtonDown("ViewC"))
        {
            if (index < 2)
            {
                index += 1;
            }
            else {
                index = 0;
            }
            
            
            //if (Cloth.transform.GetChild(index).activeSelf)
            //{
            //    Cloth.SetActive(false);
            //}
            //else
            //{
            //    Cloth.SetActive(true);
            //}
        }
        Cloth.transform.GetChild(0).gameObject.SetActive(false);
        Cloth.transform.GetChild(1).gameObject.SetActive(false);
        Cloth.transform.GetChild(2).gameObject.SetActive(false);
        Cloth.transform.GetChild(3).gameObject.SetActive(false);
        Cloth.transform.GetChild(4).gameObject.SetActive(false);
        Cloth.transform.GetChild(5).gameObject.SetActive(false);
        if (fema)
        {
            Cloth.transform.GetChild(index + femint).gameObject.SetActive(true);
        }
        else
        {
            Cloth.transform.GetChild(index).gameObject.SetActive(true);

        }
        if (Input.GetButtonDown("female")){

            if (fema)
            {
                fema = false;
                female.color = Color.red;

            }
            else
            {
                fema = true;
                female.color = Color.green;
            }
            //Logic to toggle mode on
           
        }
    }
}
