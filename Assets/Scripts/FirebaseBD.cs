using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;

public class FirebaseBD : MonoBehaviour
{

    DatabaseReference Login;
    string LED1txt;
    // Start is called before the first frame update
    void Start()
    {

        Login = FirebaseDatabase.DefaultInstance.RootReference;
        LED1txt = "ON"
        Login.setValueAsync(LED1txt).ContinueWith(task =>
        (
        ));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
