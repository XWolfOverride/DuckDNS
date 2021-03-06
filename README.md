# DuckDNS Windows Client by XWolfOverride
A simple DuckDNS updater for Windows in C#

This updater tries to be easy to use and ready for advanced users.

Download on the [Releases page](https://github.com/XWolfOverride/DuckDNS/releases).

## Easy mode
| ![](res/cap/21-main.png) |
|:--:|
| *<sub>Initial screen.</sub>* |

The first time the updater opens shows this screen where you can set the token and the domain.

Get both data from your Duck DNS account webpage:

| ![](res/cap/DuckDNS-page.png) |
|:--:|
| *<sub>DuckDNS account page</sub>* |

Set the update interval from the list or write your own.

Clicking OK will sve the configuration, hide as Tray icon / Notification area and makes an update call with the configuration.

## Updater status
The Tray icon have 3 status:

* Yellow: ![](res/tray.ico) indicates all is right and updates are correct.
* Blue: ![](res/tray_checking.ico) indicates that an update call is being processed.
* Red: ![](res/tray_error.ico) indicates some error updating domains.

In the red case a balloon will appear with information about the error.

## Tray icon options

Double click on tray icon will show the configuration dialog.

Click with the secondary mouse button will show a menu with tree options:

![](res/cap/21-menu.png)

* Update Now! > Forces a domain update round and reset intervals.
* Install Startup Shortcut > Creates a shortcut to start the updater at boot.
* Exit > Closes DuckDNS updater.

## Advanced mode

Advanced mode is only available activating the multiple domains mode.

| ![](res/cap/21-advanced.png) |
|:--:|
| *<sub>Main screen in advanced mode.</sub>* |

For more configuration options use the gear button and enable the multi domains mode.

| ![](res/cap/21-settings.png) |
|:--:|
| *<sub>Settings screen.</sub>* |

Activating it will pass the simple configuration to a domain register with the default options.

Add and remove domains in the list with the buttons at the bottom left and double click in the domian for edition.

## Domain item edition

| ![](res/cap/21-edition.png) |
|:--:|
| *<sub>Domain editor screen.</sub>* |

In this screen you can edit the domain name and the IP resolution technique.

* Server:

	The IP resolution will be done by DuckDNS server, is the more common way to get the external IP of the machine.

* Local:

	The updater resolves the computer network IP configuration.

* Fixed:

	A simple fixed IP address, not really useful for a dynamic DNS but canbe used for testing and temporal configuration.

* Host

	The updater resolves the IP based on a host name.
	
	The address depends on the network configuration.
	
* WebService

	Prior to updating the address on DuckDNS a GET call tho the web service is done, and the IP returned on this service will be used.
	
	The url path can be a file path useful for local programs.

## IP / NIC binding (v2.2)

When editing an item in v2.2 a new section will be swohn allowing user to bind the call to an specific IP or NIC.  
Useful when the computer have more than one connections to internet and a specific domain need to be resolved to specific connection.

| ![](res/cap/22-bind.png) |
|:--:|
| *<sub>Domain editor screen in v2.2.</sub>* |

Use the drop down on the Bind to IP field to select the desired IP, whis IP can not be the external one and is shown here for refernece,
when using server resolution the external IP of this NIC will be used instead.

Selecting "any" the binding logics will not be executed for the specific domain and the update call can be routed for any of the available internet connections.
