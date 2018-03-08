using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TeachOrNotClickListener: MonoBehaviour
{
	void Awake(){
		
	}
	void Start(){
	
	}
	void Update(){
	
	}
	public void WindowModeChange ()
	{
		Resolution[] resolutions = Screen.resolutions;
		Screen.SetResolution (resolutions [resolutions.Length - 1].width, resolutions [resolutions.Length - 1].height, false);  
		Screen.fullScreen = false;
	}
	public void FullScreenSet(){
		Resolution[] resolutions = Screen.resolutions;
		Screen.SetResolution(resolutions[resolutions.Length - 1].width, resolutions[resolutions.Length - 1].height,true);  
		Screen.fullScreen = true;
	}
}
