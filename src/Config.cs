﻿using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace FiestaShark {
	public sealed class Config {
		public string Interface = "";
		public ushort LowPort = 9000;
		public ushort HighPort = 9300;
		public List<Definition> Definitions = new List<Definition>();

		private static Config sInstance = null;
		internal static Config Instance {
			get {
				if (sInstance == null) {
					if (!File.Exists("Config.xml")) {
						sInstance = new Config();
						sInstance.Save();
					} else {
						using (XmlReader xr = XmlReader.Create("Config.xml")) {
							XmlSerializer xs = new XmlSerializer(typeof(Config));
							sInstance = xs.Deserialize(xr) as Config;
						}
					}
				}
				return sInstance;
			}
		}

		internal void Save() {
			XmlWriterSettings xws = new XmlWriterSettings() {
				Indent = true,
				IndentChars = "\t",
				NewLineOnAttributes = true,
				OmitXmlDeclaration = true
			};
			using (XmlWriter xw = XmlWriter.Create("Config.xml", xws)) {
				XmlSerializer xs = new XmlSerializer(typeof(Config));
				xs.Serialize(xw, this);
			}
			if (!Directory.Exists("Scripts")) Directory.CreateDirectory("Scripts");
		}
	}
}
