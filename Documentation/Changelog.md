
# Changelog

<br>

## 3.2.0.0 ( Unreleased )

-	Removed the PayPal donate button

-	Updated author name and repository links

-	Fixed URL of Check for Updates button

-	Fixed the order of the SteamCMD parameters, now the server path is set before the login ~ By jnorgan @ GitHub

-	Fixed that couldn't install a server in the root of a drive

-	Fixed that the Half-Life mod was also used to install other games

-	Fixed the error sound when installing any game

-	Fixed the text of the Browse buttons ~ By jnorgan @ GitHub

-	Added Insurgency to the game lists

-	Added Icarus to the list of games to install ~ By jnorgan @ GitHub

-	Removed Dota 2 and Half-Life Dedicated Server from the Run Server tab, they don't use SRCDS

-	Fixed the game parameter of Alien Swarm and the Steam App ID of Left 4 Dead

-	Fixed that a config with an unknown game was loaded with the game selected previously

-	Added a button to remove games from the list

-	Adding a custom game with a used ID replaces it, instead of crashing the program

-	Fixed a crash at startup when the list of games had a repeated ID

-	The sounds are only played when there is an error

-	The folders are selected with the Windows Explorer dialog, with access to all the drives

-	Added Counter-Strike 2 and Team Fortress 2 Classified, both to install and to run servers

-	The server path of the Update/Install tab is saved

-	Fixed that a path with the character & wasn't loaded correctly

-	Added a text-box for the login token of the server (GSLT), it can be saved and loaded with the config file

-	Fixed that the RCON password was never sent to the server

-	The Steam password can be left empty to use the session saved by SteamCMD, without typing the Steam Guard code again

-	A config file can be loaded when the program is opened, using it as a parameter or dropping it on the program

-	Fixed that a config with special characters wasn't loaded correctly

-	Fixed that some options of the previous config were kept when another one was loaded

-	Fixed some crashes when a config file can't be saved or loaded

-	Fixed that the program wasn't loaded correctly when the public IP couldn't be obtained

-	The Settings and Logs folders are always next to the program

-	The server of Team Fortress 2, needed by Team Fortress 2 Classified, can be installed with it in the folder 'tf2'

-	The folder of Team Fortress 2 used by Team Fortress 2 Classified is set in the Custom Commands with `-tf_path`

-	Fixed that the Custom Commands window didn't save everything that was typed and could only be closed with Enter

-	The game configuration is enabled when the path of the server is correct, and the game is detected automatically

<br>

## 3.1.0.2

-	Custom Mod now is saved by XML config ~ By Melo88 @ GitHub

<br>

## 3.1.0.1

-	Added a text-box on the bottom right corner with the public IP

-	Removed useless variables

-	Removed Mani Admin Plugin button from the Addons list
	
	(Still available at the Internet Machine: Wayback Machine)

-	Added a PayPal donate button

<br>

## 3.1.0.0

-	Added maintainable custom Game ID List via an XML file ~ By Captnwalker1 @ GitHub
	
	(Keep using Half-Life Dedicated Server for GoldSrc games)

-	Moved all XML files to the Settings folder	

<br>
	
## 3.0.1.5

-	Fixed that couldn't find `steamcmd.exe` at launch the program

<br>

## 3.0.1.4

- 	Minor fixes

<br>

## 3.0.1.3

- 	Set a maximum value of 64 for Max Players

- 	Set a minimum value of 0 for the UDP Port

<br>

## 3.0.1.2

-	Fixed URL of Changelog and License buttons

<br>

## 3.0.1.1

-	Fixed the GUI not working properly with a DPI 125% or 150% on Windows

-	Added an option for enable/disable the using the console

-	Updated author name

<br>

## 3.0.1.0 ( Unreleased )

-	Added Spanish translation

<br>

## 3.0.0.2

-	SteamCMD uses the new console

<br>

## 3.0.0.1 ( Unreleased )

-	Improved Codestyle / Code formatting ~ By Giswald @ GitHub

<br>

## 3.0.0.0 ( Unreleased )

-	Added Half-Life Dedicated Server to the game list
	
	(This supports all the mods that works on GoldSrc engine)

-	Added a console

-	Added new folder for logs

-	Disabled the option to write in combo boxes

-	When the program doesn't find the CFG folder in the server, it creates a new one

<br>

## 2.1.1.2

-	Added Alien Swarm, Dota 2, and Left 4 Dead to the game list
	
	(The Dota 2 servers needs additional files for work properly.)

<br>

## 2.1.1.1

-	Added a checkbox for enable/disable the validation files ~ Request by CyberStars @ AlliedModders

-	Added a header image for the Steam library

-	Little improvement in logo and icon

-	Removed the arrows when hover the cursor at borders of the window

<br>

## 2.1.1.0

-	Added a button for SteamCMD log files

<br>

## 2.1.0.1

-	Improved the code with adding the icon file as resource

-	Moved the icon file to Resource/Icons folder

<br>

## 2.1.0.0

-	Added a textbox for add more command-line options, with a help button. This options can be saved and loaded with the config file

-	Little change on BannerSplash image

<br>

## 2.0.2.0

-	Updated correctly the license

-	Reorganized resources

-	Renamed all forms

-	Added direct button for open maplist.txt and mapcycle.txt

-	Added a list for config files of SourceMod (.txt, .cfg, and .ini)

-	Added shortcutkeys for Save (Ctrl + S) and Load (Ctrl + O)

<br>

## 2.0.1.2

-	New icon

-	Added a loading screen

<br>

## 2.0.1.1

-	Documented all the changes in changelog

-	Edited "About" window design

-	License and changelog files are shown in RAW mode if cant find the local file

<br>

## 2.0.1.0

-	Added the changelog file

-	Added the license file

-	Removed useless content

-	Updated "?" button in the "Update/Install" tab with a new URL

<br>

## 2.0.0.1

-	Fixed a crash related when the user try to run a server with a wrong path

-	Added a sample config

## 2.0.0.0

-	Run Server Tab

-	Autosave SteamCMD path

-	New menu

	-	Save/Load configuration

	-	List of current CFG files

	-	Direct link to MOTD

<br>

## 1.0.0.1

-	Added an input to choose the path where is located the file `steamcmd.exe`

<br>

## 1.0.0.0

-	Release

<br>