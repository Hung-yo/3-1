using UnityEngine;

public class DeathDestroy : Death
{
    public AudioSource deathClip;
    public GameObject splitObject;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void Die()
    {
        DeathEvent();
        Destroy(gameObject);
    }

    public virtual void DeathEvent()
    {
        Debug.Log("Death event triggered");
        if (deathClip != null)
        {
            AudioSource.PlayClipAtPoint(deathClip.clip, transform.position);
        }
        if (splitObject != null)
        {
            Instantiate(splitObject, transform.position - new Vector3(.2f, 0, 0), transform.rotation); // left fragment
            Instantiate(splitObject, transform.position + new Vector3(.2f, 0, 0), transform.rotation); // right fragment
            Instantiate(splitObject, transform.position + new Vector3(0, .2f, 0), transform.rotation); // top fragment
            Instantiate(splitObject, transform.position - new Vector3(0, .2f, 0), transform.rotation); // bottom fragment
        }
    }
}
