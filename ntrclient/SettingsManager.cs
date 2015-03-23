using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ntrclient {
	public class SettingsManager {
		public string[] quickCmds {set; get;}

		public void init() {
			if (quickCmds == null ) {
				quickCmds = new string[10];
				for (int i = 0; i < quickCmds.Length; i++) {
					quickCmds[i] = "";
				}
			}
		}

		public static void SaveToXml(string filePath, SettingsManager sourceObj) {

				try {
					using (StreamWriter writer = new StreamWriter(filePath)) {
						System.Xml.Serialization.XmlSerializer xmlSerializer = 
							new System.Xml.Serialization.XmlSerializer(sourceObj.GetType()); 
						xmlSerializer.Serialize(writer, sourceObj);
				}
				
				} catch(Exception ex) {
					MessageBox.Show(ex.Message);
				}

		}

		public static SettingsManager LoadFromXml(string filePath) {
			try {
				using (StreamReader reader = new StreamReader(filePath)) {
					System.Xml.Serialization.XmlSerializer xmlSerializer = 
						new System.Xml.Serialization.XmlSerializer(typeof(SettingsManager));
					return (SettingsManager)xmlSerializer.Deserialize(reader);
				}
			}
			catch (Exception ex) {
				MessageBox.Show(ex.Message);
			}
			return new SettingsManager();
		}
	}
}
