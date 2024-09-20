using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public bool alive;

    //colour 
    public Color DefaultColour = Color.green;
    public Color HighligtColour = Color.red;
    public int Lerpspeed = 1;
    public SpriteRenderer spriteRenderer;



    public Material _mat;

    public void Start()

    {
        spriteRenderer = GetComponent<SpriteRenderer>();


        _mat = spriteRenderer.material;
        DefaultColour = _mat.GetColor("_Color");

        
        
            StartCoroutine(UpdateColour());  
       
    }

    public void UpdateStatus()
    {

        if (spriteRenderer == null)
        {

            spriteRenderer = GetComponent<SpriteRenderer>();

        }

        spriteRenderer.enabled = alive;

    }

    public void OnEnable()
    {
        StartCoroutine(UpdateColour());

    }

    public IEnumerator UpdateColour()
    {
        while (true)
        {
            float lerpvalue = Mathf.PingPong(Lerpspeed * Time.time, 1);

            Color LerpColor = Color.Lerp(DefaultColour,HighligtColour,lerpvalue);
            _mat.SetColor("_Color", LerpColor);

            yield return new WaitForEndOfFrame();


        }

    }
}
