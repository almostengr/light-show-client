# Light Show Connect

## Table of Contents

* [Configuration](#configuration)
* [Run Mode](#run-mode)
* [Class Libraries](#class-libraries)
* [Bug Reports and Feature Requests](#bug-reports-and-feature-requests)

## Configuration

These are the settings that control the functionality of the Connect software.

More information to be documented here later.

## Run Mode

Run Mode is the mode the Connect software is running in. The modes are as follows:

### Offline

No song information is sent to the server. Also no requests are accepted on your displays page.

This mode should be used when your show is powered off or you are doing local testing.

### Online, Rejecting Requests

Song infomraiton is sent to the server and displayed on your display's page. No requests are
accepted via your display's page.

This mode should be used when your display is online, but you do not want viewers to have
control of your display.

### Online, Accepting Requests

Song infomraiton is sent to the server and displayed on your display's page. Requests are
accepted via your display's page and sent to the Connect software when requested.

This mode should be used when your display is online and has viewers.

## Class Libraries

C# Class Libraries for Falcon Pi Player, and Light Show Website are available on nuget.org.

## Bug Reports and Feature Requests

Bug reports, issues, and feature requests should be submitted to the project repository located
at [https://github.com/almostengr/light-show-fpp](https://github.com/almostengr/light-show-fpp).
