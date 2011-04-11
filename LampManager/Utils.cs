using System;

namespace LampManager {
	
	public class Utils {
		
		public Utils () {
			
		}
		
		public static string FileNameWithoutExt(string path) {
			System.IO.FileInfo fileInfo = new System.IO.FileInfo(path);
			return fileInfo.Name.Substring(0, fileInfo.Name.Length - fileInfo.Extension.Length);
		}
		
		public static string FileName(string path) {
			System.IO.FileInfo fileInfo = new System.IO.FileInfo(path);
			return fileInfo.Name;
		}
	}
}