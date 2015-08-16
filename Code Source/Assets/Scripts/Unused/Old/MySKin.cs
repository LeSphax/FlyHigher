using UnityEngine;
using System.Collections;

public class MySkin {
	public static GUISkin skinDefault;
	private static GUISkin skin;
	public static GUISkin skinRight;
	private static int test;
	private static Color GUIBackGroundColor;

	public static void setSkin (GUISkin skinIn800, GUISkin skinIn700, GUISkin skinIn600, GUISkin skinIn500, GUISkin skinIn400) {
		if (Screen.width > 7800) {
			skin = skinIn800;
		} else if (Screen.width > 700) {
			skin = skinIn700;
		} else if (Screen.width > 600) {
			skin = skinIn600;
		} else if (Screen.width > 500) {
			skin = skinIn500;
		} else {
			skin = skinIn400;
		}
	}
	public static GUISkin getSkin(){
		return skin;
	}
	//public static GUISkin getDefaultSkin(){
	//	return skinDefault;
	//}

	public static void setColor(Color color){
		GUIBackGroundColor = color;
	}
	public static Color getColor(){
		return GUIBackGroundColor;
	}
}
