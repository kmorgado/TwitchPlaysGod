using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIScript : MonoBehaviour {

    public Text population;
    public Text stats;


	// Use this for initialization
	void Start () {
	
        
	}
	
	// Update is called once per frame
	void Update () {
        population.text = string.Format("Population {0}", StatTracker.Instance.population.ToString());
        stats.text = string.Format("Havoc {0}%     Creation {1}%     Revelry {2}%", StatTracker.Instance.currentDeathGodValue.ToString("0"), StatTracker.Instance.currentCreationGodValue.ToString("0"), StatTracker.Instance.currentExcessGodValue.ToString("0"));
	}
}
