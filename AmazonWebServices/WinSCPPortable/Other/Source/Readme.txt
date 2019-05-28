WinSCP Portable Launcher
========================
Copyright 2004-2008 John T. Haller

Website: http://PortableApps.com/WinSCPPortable

This software is OSI Certified Open Source Software.
OSI Certified is a certification mark of the Open Source Initiative.

This program is free software; you can redistribute it and/or
modify it under the terms of the GNU General Public License
as published by the Free Software Foundation; either version 2
of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.


ABOUT WinSCP PORTABLE
=====================
The WinSCP Portable Launcher allows you to run WinSCP from a removable drive whose letter changes as you move it to another computer.  The program can be entirely self-contained on the drive and then used on any Windows computer.


LICENSE
=======
This code is released under the GPL.  The full code is included with this package as WinSCPPortable.nsi.


INSTALLATION / DIRECTORY STRUCTURE
==================================
The program expects this directory structure:

-\ <--- Directory with WinSCPPortable.exe
	+\App\
		+\WinSCP\
	+\Data\
		+\settings\

WinSCPPORTABLE.INI CONFIGURATION
===============================
The WinSCP Portable Launcher will look for an ini file called WinSCPPortable.ini.  If you are happy with the default options, it is not necessary, though.  The INI file is formatted as follows:

[WinSCPPortable]
AdditionalParameters=
DisableSplashScreen=false

The AdditionalParameters entry allows you to pass additional commandline parameter entries to WinSCP.exe.  Whatever you enter here will be appended to the call to WinSCP.exe.

The DisableSplashScreen entry allows you to run the WinSCP Portable Launcher without the splash screen showing up.  The default is false.