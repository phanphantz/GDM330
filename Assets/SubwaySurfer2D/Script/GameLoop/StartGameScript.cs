using UnityEngine;

namespace SuperGame.SubwaySurfer2D
{
    public class StartGameScript : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Time.timeScale = 0;
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Time.timeScale = 1.0f;
                this.gameObject.SetActive(false);
            }
        }
    }
}
