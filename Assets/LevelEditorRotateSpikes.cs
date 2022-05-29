using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditorRotateSpikes : MonoBehaviour
{

    public GameObject prefab;
    private GameObject selectedObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnClick() {
        var objectPosition = selectedObject.transform.position;
        
        objectPosition.z = transform.position.z  + 3.6f;
        objectPosition.x = transform.position.x;
        objectPosition.y = transform.position.y;
       
        var clone = selectedObject;
   
   
        clone = Instantiate(prefab,  objectPosition, transform.rotation);
   
   
        var objectRotation = transform.rotation;
        print(objectRotation.eulerAngles.y);
 
        clone.transform.RotateAround(transform.position,Vector3.up,objectRotation.eulerAngles.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}