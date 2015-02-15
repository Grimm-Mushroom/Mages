using UnityEngine;
using System.Collections;

public class FireLightAnimator : MonoBehaviour {
	
	float newIntensity;
	public float maxIntensity = 4.0f;
	public float minIntensity = 0.1f;
	
	
	
	public float intesityChangeSpeed = 0.1f;
	
	
	// Use this for initialization
	void Start () {
		
		newIntensity = getNewIntesity ();
		
	}
	
	
	float getNewIntesity(){
		float result = Random.Range (minIntensity, maxIntensity);
	//	Debug.Log ("newIn: " +  result);
		return result;
		
	}
	
	
	// Update is called once per frame
	void Update () {
		
		
		if (newIntensity < light.intensity) {
			light.intensity -= intesityChangeSpeed;
			if(newIntensity > light.intensity){
				newIntensity  = getNewIntesity();
			}
		} else {
			light.intensity += intesityChangeSpeed;
			if(newIntensity < light.intensity){
				newIntensity = getNewIntesity();
			}
		}
		
		
	}
}
