using System;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;

public class PostProcess
{
	[PostProcessBuild()]
	public static void PlistDocumentAPIExample(BuildTarget buildTarget, string pathToBuiltProject)
	{
		if (buildTarget == BuildTarget.iOS)
		{
			// Read the contents of the Info.plist file that was generated during the build
			var plistPath = pathToBuiltProject + "/Info.plist";
			var plist = new PlistDocument();
			plist.ReadFromFile(plistPath);

			// Get root plist element
			var rootDict = plist.root;

			// Use helper methods such as SetBoolean, SetInteger or SetDate to modify or create new Info.plist entries
			// If a specified key doesn't already exist in the Info.plist, a new entry will be created
			rootDict.SetBoolean("ExampleBoolean", true);
			rootDict.SetInteger("ExampleInteger", 10);
			rootDict.SetDate("ExampleDate", DateTime.Today);

			// Write the changes to the Info.plist file
			plist.WriteToFile(plistPath);
		}
	}
}
