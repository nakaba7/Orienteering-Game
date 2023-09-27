using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostDataRecord : MonoBehaviour
{
    [SerializeField]private int postNumber;
    // Start is called before the first frame update
    public int getPostNumber(){
        return postNumber;
    }
}
