using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class LanguageText : MonoBehaviour
{

		private static LanguageText instanceLangue;
		private Dictionary<string,string> dicoUITexts;
		private Dictionary<string, List<string>>dicoHistory;


		private LanguageText ()
		{
				string defaultLanguage = Application.systemLanguage.ToString ();
				SetLanguage ("english");
			
				/*
				foreach (KeyValuePair<string,List<string>> item in dicoHistory) {
		
						Debug.Log ("Clef " + item.Key);
						foreach (string s in item.Value) {
								Debug.Log ("Value : " + s);
						}
				}*/

		}



		public static LanguageText Instance {
				get {
						if (instanceLangue == null) {
								instanceLangue = new LanguageText ();
						}
						return instanceLangue;
				}
		}



		public string GetUIText (string id)
		{
				if (!dicoUITexts.ContainsKey (id)) {
						Debug.LogError ("The specified string does not exist: " + id);
						return "";
				}		
				return dicoUITexts [id];
		}

		public List<string> GetHistoryTexts (string id)
		{
				if (!dicoHistory.ContainsKey (id)) {
						Debug.LogError ("The specified string does not exist: " + id);
						return null;
				}		
				return dicoHistory [id];
		}


		public void SetLanguage (string language)
		{
				ParseXmlFile ("language.xml", language.ToLower ());
		}




		private void ParseXmlFile (string path, string language)
		{
				dicoUITexts = new Dictionary<string,string> ();
				dicoHistory = new Dictionary<string,List<string>> ();

				XmlDocument xml = new XmlDocument ();
				xml.Load (path);
	
				XmlElement elementLanguage = xml.DocumentElement [language]; // The xml element <english> for example

				if (elementLanguage != null) {
					
						XmlElement elementUITexts = elementLanguage ["uitexts"];
						if (elementUITexts != null) {
								foreach (XmlNode nodeUITexts in elementUITexts.ChildNodes) {
										dicoUITexts.Add (nodeUITexts .Attributes ["id"].Value, nodeUITexts.InnerText);
								}
						}


						XmlElement elementHistory = elementLanguage ["history"];
						if (elementHistory != null) {
								foreach (XmlNode nodeDialog in elementHistory.ChildNodes) {
										List<string> tmpList = new List<string> ();
										foreach (XmlNode nodeStringDialog in nodeDialog.ChildNodes) {
												tmpList.Add (nodeStringDialog.InnerText);
										}
										dicoHistory.Add (nodeDialog.Attributes ["id"].Value, tmpList);
								}
						}
				} else {
						Debug.LogError ("Error XML file : element " + language + " not found");
				}
			
		}
}
