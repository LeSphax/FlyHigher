using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class LanguageText 
{

		private static LanguageText instanceLangue;
		private Dictionary<string,string> dico;


		private LanguageText ()
		{
				string defaultLanguage = Application.systemLanguage.ToString ();
				SetLanguage ("English");
		}



		public static LanguageText Instance {
				get {
						if (instanceLangue == null) {
								instanceLangue = new LanguageText ();
						}
						return instanceLangue;
				}
		}



		public string GetText (string id)
		{
				if (!dico.ContainsKey (id)) {
						Debug.LogError ("The specified string does not exist: " + id);
						return "";
				}		
				return dico [id];
		}


		public void SetLanguage (string language)
		{
				ParseXmlFile ("language.xml", language.ToLower ());
		}




		private void ParseXmlFile (string path, string language)
		{
				XmlDocument xml = new XmlDocument ();
				/*try {*/
				xml.Load (path);
				/*} catch (XmlException e) {
						Debug.Log ("Error XML file : Parsing error ");
				}*/
		
				dico = new Dictionary<string,string> ();
				XmlElement elementLanguage = xml.DocumentElement [language]; // The xml element <english> for example
				if (elementLanguage != null) {
						IEnumerator elemEnum = elementLanguage .GetEnumerator ();
						while (elemEnum.MoveNext()) {
								XmlElement xmlItem = (XmlElement)elemEnum.Current;
								dico.Add (xmlItem.GetAttribute ("id"), xmlItem.InnerText);
						}
				} else {
						Debug.LogError ("Error XML file : element " + language + " not found");
				}
			
		}
}
