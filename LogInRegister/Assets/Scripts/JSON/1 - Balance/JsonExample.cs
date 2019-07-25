using System.Collections.Generic;
using UnityEngine;

public class JsonExample : MonoBehaviour
{

    public DiscussionList DiscussionList = new DiscussionList();

    // Start is called before the first frame update
    void Start()
    {
        TextAsset asset = Resources.Load("Discussion") as TextAsset;
        if (asset != null) {
            DiscussionList = JsonUtility.FromJson<DiscussionList>(asset.text);

            foreach (Discussion discussion in DiscussionList.Discussion) {
                print(discussion.Theme);
                print(discussion.Statement);
            }
        }
        else {
            print("Asset is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
