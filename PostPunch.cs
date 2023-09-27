using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PostPunch : MonoBehaviour
{

    private List<int> postNumList;

    public List<int> getPostNumList(){
        return postNumList;
    }
    // Start is called before the first frame update
    void Start()
    {
        postNumList = new List<int>();
    }

    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.CompareTag("Post")){
            int postnum = collider.gameObject.GetComponent<PostDataRecord>().getPostNumber();
            postNumList.Add(postnum);
        }
    }

    void Update(){
        Debug.Log(string.Join(",", postNumList.Select(n => n.ToString())));
    }
}
