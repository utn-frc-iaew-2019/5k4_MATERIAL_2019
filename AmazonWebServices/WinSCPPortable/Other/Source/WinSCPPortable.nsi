;Copyright (C) 2004-2009 John T. Haller of PortableApps.com

;Website: http://portableapps.com/WinSCPPortable

;This software is OSI Certified Open Source Software.
;OSI Certified is a certification mark of the Open Source Initiative.

;This program is free software; you can redistribute it and/or
;modify it under the terms of the GNU General Public License
;as published by the Free Software Foundation; either version 2
;of the License, or (at your option) any later version.

;This program is distributed in the hope that it will be useful,
;but WITHOUT ANY WARRANTY; without even the implied warranty of
;MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
;GNU General Public License for more details.

;You should have received a copy of the GNU General Public License
;along with this program; if not, write to the Free Software
;Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.

!define PORTABLEAPPNAME "WinSCP Portable"
!define APPNAME "WinSCP"
!define NAME "WinSCPPortable"
!define VER "1.6.4.0"
!define WEBSITE "PortableApps.com/WinSCPPortable"
!define DEFAULTEXE "WinSCP.exe"
!define DEFAULTAPPDIR "WinSCP"
!define LAUNCHERLANGUAGE "English"

;=== Program Details
Name "${PORTABLEAPPNAME}"
OutFile "..\..\${NAME}.exe"
Caption "${PORTABLEAPPNAME} | PortableApps.com"
VIProductVersion "${VER}"
VIAddVersionKey ProductName "${PORTABLEAPPNAME}"
VIAddVersionKey Comments "Allows ${APPNAME} to be run from a removable drive.  For additional details, visit ${WEBSITE}"
VIAddVersionKey CompanyName "PortableApps.com"
VIAddVersionKey LegalCopyright "John T. Haller"
VIAddVersionKey FileDescription "${PORTABLEAPPNAME}"
VIAddVersionKey FileVersion "${VER}"
VIAddVersionKey ProductVersion "${VER}"
VIAddVersionKey InternalName "${PORTABLEAPPNAME}"
VIAddVersionKey LegalTrademarks "PortableApps.com is a Trademark of Rare Ideas, LLC."
VIAddVersionKey OriginalFilename "${NAME}.exe"
;VIAddVersionKey PrivateBuild ""
;VIAddVersionKey SpecialBuild ""

;=== Runtime Switches
CRCCheck On
WindowIcon Off
SilentInstall Silent
AutoCloseWindow True
RequestExecutionLevel user

; Best Compression
SetCompress Auto
SetCompressor /SOLID lzma
SetCompressorDictSize 32
SetDatablockOptimize On

;=== Include
;(Standard NSIS)
!include FileFunc.nsh
!insertmacro GetParameters

;(Custom)
!include ReadINIStrWithDefault.nsh
!include StrRep.nsh

;=== Program Icon
Icon "..\..\App\AppInfo\appicon.ico"

;=== Icon & Stye ===
!define MUI_ICON "..\..\App\AppInfo\appicon.ico"

;=== Languages
LoadLanguageFile "${NSISDIR}\Contrib\Language files\${LAUNCHERLANGUAGE}.nlf"
!include PortableApps.comLauncherLANG_${LAUNCHERLANGUAGE}.nsh

Var PROGRAMDIRECTORY
Var SETTINGSDIRECTORY
Var ADDITIONALPARAMETERS
Var EXECSTRING
Var PROGRAMEXECUTABLE
Var DISABLESPLASHSCREEN
Var MISSINGFILEORPATH

Section "Main"
	;CheckINI:
		IfFileExists "$EXEDIR\${NAME}.ini" "" SetRemainingVariables
			${ReadINIStrWithDefault} $ADDITIONALPARAMETERS "$EXEDIR\${NAME}.ini" "${NAME}" "AdditionalParameters" ""
			${ReadINIStrWithDefault} $DISABLESPLASHSCREEN "$EXEDIR\${NAME}.ini" "${NAME}" "DisableSplashScreen" "false"

	SetRemainingVariables:
		StrCpy $PROGRAMEXECUTABLE "${DEFAULTEXE}"
		StrCpy $PROGRAMDIRECTORY "$EXEDIR\App\${DEFAULTAPPDIR}"
		StrCpy $SETTINGSDIRECTORY "$EXEDIR\Data\settings"
		IfFileExists "$PROGRAMDIRECTORY\$PROGRAMEXECUTABLE" FoundProgramEXE

	;NoProgramEXE:
		;=== Program executable not where expected
		StrCpy $MISSINGFILEORPATH $PROGRAMEXECUTABLE
		MessageBox MB_OK|MB_ICONEXCLAMATION `$(LauncherFileNotFound)`
		Abort
		
	FoundProgramEXE:
		StrCmp $DISABLESPLASHSCREEN "true" GetPassedParameters
			;=== Show the splash screen while processing registry entries
			InitPluginsDir
			File /oname=$PLUGINSDIR\splash.jpg "${NAME}.jpg"
			newadvsplash::show /NOUNLOAD 1200 0 0 -1 /L $PLUGINSDIR\splash.jpg
	
	GetPassedParameters:
		StrCpy $EXECSTRING `"$PROGRAMDIRECTORY\$PROGRAMEXECUTABLE" /ini="$EXEDIR\Data\settings\winscp.ini" /log="$EXEDIR\Data\settings\winscp.log"`
		
		;=== Get any passed parameters
		${GetParameters} $0
		StrCmp "'$0'" "''" AdditionalParameters

		;=== Add the commandline parameters
		StrCpy $EXECSTRING `$EXECSTRING $0`

	AdditionalParameters:
		StrCmp $ADDITIONALPARAMETERS "" SettingsDirectory

		;=== Additional Parameters
		StrCpy $EXECSTRING `$EXECSTRING $ADDITIONALPARAMETERS`
	
	SettingsDirectory:
		;=== Set the settings directory if we have a path
		IfFileExists "$SETTINGSDIRECTORY\winscp.ini" RestoreSettings
			CreateDirectory $SETTINGSDIRECTORY
			CopyFiles `$EXEDIR\App\DefaultData\winscp.ini` `$EXEDIR\Data\settings`
			Delete `$EXEDIR\App\winscp\winscp.rnd`
	
	RestoreSettings:
		WriteINIStr "$SETTINGSDIRECTORY\winscp.ini" "Configuration\Interface" "RandomSeedFile" "%2E%5Cwinscp.rnd"
		WriteINIStr "$SETTINGSDIRECTORY\winscp.ini" "Configuration\Interface" "DDTemporaryDirectory" "%2E%5C"
		WriteINIStr "$SETTINGSDIRECTORY\winscp.ini" "Configuration\Interface" "PuttySession" "WinSCP%20Portable%20Temporary%20Session"
		StrCpy $0 `$PROGRAMDIRECTORY\PuTTYPortableLinker.exe`
		${StrReplace} $1 "\" "%5C" $0
		WriteINIStr "$SETTINGSDIRECTORY\winscp.ini" "Configuration\Interface" "PuttyPath" "$1"
		
	;GetCurrentLanguage
		ReadINIStr $0 "$SETTINGSDIRECTORY\winscp.ini" "Configuration\Interface" "LocaleSafe"
		ReadEnvStr $1 "PortableApps.comLocaleID"
		StrCmp $1 "" LaunchNow ;if blank, just launch
		StrCmp $0 $1 LaunchNow ;if the same, just launch
		StrCmp $1 "1025" "" +2 ;Arabic
			IfFileExists `$PROGRAMDIRECTORY\winscp.ar` SetNewLanguage LaunchNow
		StrCmp $1 "1028" "" +2 ;Traditional Chinese
			IfFileExists `$PROGRAMDIRECTORY\winscp.ch` SetNewLanguage LaunchNow
		StrCmp $1 "2052" "" +2 ;Simplified Chinese
			IfFileExists `$PROGRAMDIRECTORY\winscp.chs` SetNewLanguage LaunchNow
		StrCmp $1 "1029" "" +2 ;Czech
			IfFileExists `$PROGRAMDIRECTORY\winscp.cs` SetNewLanguage LaunchNow
		StrCmp $1 "1031" "" +2 ;German
			IfFileExists `$PROGRAMDIRECTORY\winscp.de` SetNewLanguage LaunchNow
		StrCmp $1 "1034" "" +2 ;Spanish
			IfFileExists `$PROGRAMDIRECTORY\winscp.es` SetNewLanguage LaunchNow
		StrCmp $1 "3082" "" +2 ;Spanish International
			IfFileExists `$PROGRAMDIRECTORY\winscp.es` SetNewLanguage LaunchNow
		StrCmp $1 "1035" "" +2 ;Finnish
			IfFileExists `$PROGRAMDIRECTORY\winscp.fi` SetNewLanguage LaunchNow
		StrCmp $1 "1036" "" +2 ;French
			IfFileExists `$PROGRAMDIRECTORY\winscp.fr` SetNewLanguage LaunchNow
		StrCmp $1 "1038" "" +2 ;Hungarian
			IfFileExists `$PROGRAMDIRECTORY\winscp.hu` SetNewLanguage LaunchNow	
		StrCmp $1 "1050" "" +2 ;Croation
			IfFileExists `$PROGRAMDIRECTORY\winscp.hr` SetNewLanguage LaunchNow
		StrCmp $1 "1040" "" +2 ;Italian
			IfFileExists `$PROGRAMDIRECTORY\winscp.it` SetNewLanguage LaunchNow
		StrCmp $1 "1041" "" +2 ;Japanese
			IfFileExists `$PROGRAMDIRECTORY\winscp.jp` SetNewLanguage LaunchNow	
		StrCmp $1 "1042" "" +2 ;Korean
			IfFileExists `$PROGRAMDIRECTORY\winscp.ko` SetNewLanguage LaunchNow
		StrCmp $1 "1043" "" +2 ;Dutch
			IfFileExists `$PROGRAMDIRECTORY\winscp.nl` SetNewLanguage LaunchNow
		StrCmp $1 "1045" "" +2 ;Polish
			IfFileExists `$PROGRAMDIRECTORY\winscp.pl` SetNewLanguage LaunchNow	
		StrCmp $1 "1046" "" +2 ;PortugueseBR
			IfFileExists `$PROGRAMDIRECTORY\winscp.pt` SetNewLanguage LaunchNow
		StrCmp $1 "2070" "" +2 ;Portuguese
			IfFileExists `$PROGRAMDIRECTORY\winscp.ptg` SetNewLanguage LaunchNow	
		StrCmp $1 "1049" "" +2 ;Russian
			IfFileExists `$PROGRAMDIRECTORY\winscp.ru` SetNewLanguage LaunchNow	
		StrCmp $1 "3098" "" LaunchNow ;Serbian
			IfFileExists `$PROGRAMDIRECTORY\winscp.srl` SetNewLanguage LaunchNow
		StrCmp $1 "2074" "" LaunchNow ;Serbian Latin
			IfFileExists `$PROGRAMDIRECTORY\winscp.srl` SetNewLanguage LaunchNow
		StrCmp $1 "1053" "" LaunchNow ;Swedish
			IfFileExists `$PROGRAMDIRECTORY\winscp.sv` SetNewLanguage LaunchNow
		StrCmp $1 "1055" "" LaunchNow ;Turkish
			IfFileExists `$PROGRAMDIRECTORY\winscp.tr` SetNewLanguage LaunchNow
		StrCmp $1 "1058" "" LaunchNow ;Ukrainian
			IfFileExists `$PROGRAMDIRECTORY\winscp.uk` SetNewLanguage LaunchNow
		Goto LaunchNow
			
	SetNewLanguage:
		WriteINIStr "$SETTINGSDIRECTORY\winscp.ini" "Configuration\Interface" "LocaleSafe" "$1"
	
	LaunchNow:
		Sleep 100
		SetOutPath $PROGRAMDIRECTORY
		Exec $EXECSTRING
		newadvsplash::stop /WAIT
SectionEnd