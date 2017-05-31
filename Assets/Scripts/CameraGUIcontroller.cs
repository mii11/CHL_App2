using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraGUIcontroller : MonoBehaviour {
	public Text tryText;

	public void setStringToText(string str){
		tryText.text = str;
	}

//	void OnGUI(){
//		Rect position1 = new Rect (0, 250, 0,40);
//		GUIStyle guiStyle = new GUIStyle ();
//		GUIStyleState styleState = new GUIStyleState ();
//		string str = gameManagerScript.guiTryagain;
//		print ("現在のgameManagerScript.guiTryagainは"+ gameManagerScript.guiTryagain);
//
//		styleState.textColor = Color.black;
//		guiStyle.normal = styleState;
//		guiStyle.fontSize = 40;
//		GUI.Label (position1, str, guiStyle);
//	}

	//	void OnGUI(){
	//		GUIStyle guiStyle = new GUIStyle ();
	//		GUIStyleState styleState = new GUIStyleState ();
	//
	//		styleState.textColor = Color.black;
	//		guiStyle.normal = styleState;
	//		guiStyle.fontSize = 40;
	//		GUI.Label (new Rect (10, 10, 300, 100), "Try again !", guiStyle);
	//
	//	}


}
