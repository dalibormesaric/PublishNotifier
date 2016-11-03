https://channel9.msdn.com/events/Build/2016/B886
https://visualstudiogallery.msdn.microsoft.com/ab39a092-1343-46e2-b0f1-6a3f91155aa6
1. Delete
	- index.html
	- stylesheet.css
2. Edit source.extension.vsixmanifest
	- Product Name
	- Product ID (leave GUID)
	- Description
	- Tags
3. Add -> New Item -> Extensibility -> Visual Studio Package (VSPackage.cs)
4. VSPackage
	- Add: [ProvideAutoLoad(UIContextGuids80.SolutionBuilding)] before [Guid(VSPackage.PackageGuidString)]

70. Tools -> Export Image Moniker...
	- Resources\Icon.png - 90x90
	- Resources\Preview - 175x175
71. Edit vsixmanifest
	- Icon
	- Preview Image

80. Solution -> Right-Click -> Extensibility Tools -> Prepare for GitHub...
81. Edit CHANGELOG.md
82. Edit README.md

90. Delete
	- VSPackage.resx
	- Resources/VSPackage.ico
91. source.extension.vsixmanifest -> Right-Click -> Auto-sync Resx and Icon files
92. Edit VSPackage.cs
	- version number -> Vsix.Version
96. Edit VSPackage.cs
	- (remove SuppressMessage)

99. Project -> Right-Click -> Properties -> Signing
	- Uncheck: Sign the assembly
	- Delete: Key.snk
100. Solution -> Right-Click -> Image Optimizer -> Lossy Optimize Images