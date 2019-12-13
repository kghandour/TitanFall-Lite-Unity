using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Dashing : MonoBehaviour
{
    private int dashes = 3;
    public Text dashesCounter;

    private Rigidbody rb;

    private TitanHealthAndDisembarkScript titan_script;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        titan_script = GetComponent<TitanHealthAndDisembarkScript>();
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

                titan_script.invincible++;
                reset_invincible();
            }
        }

        dashesCounter.text = "Dash counter: " + dashes;
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

    private async void reset_invincible()
    {
        await Task.Delay(1000);
        titan_script.invincible--;
    }
}
