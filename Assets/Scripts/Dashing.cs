using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Dashing : MonoBehaviour
{
    private int dashes = 3;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (dashes >= 3)
            {
                regenerate_dashes();
            }

            if (dashes > 0)
            {
                dashes--;

                rb.AddForce(rb.velocity.normalized * 150, ForceMode.Impulse);
            }
        }
    }

    private async void regenerate_dashes()
    {
        await Task.Delay(5000);

        dashes++;

        if(dashes < 3)
        {
            regenerate_dashes();
        }
    }
}
