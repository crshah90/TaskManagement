# TaskManagement
Assign daily task with desktop alerts and notification and personal messaging services

Tired of sending emails and what to write while sending an update to the team leader. Well, u need not worry!
Tired of asking an update of the task from the subordinates and then working on excel to create a report, well u need not worry!

This desktop application focuses on leveraging windows forms and WCF services to automate the above routine with an added functionality of chat service. 

There are two projects in this.
1) Chat-server (Startup Project)
2) Chat-Client (Called by Chat-Server project)

In chat-server, a customized windows forms calendar is created according to the client billing cycle and the team leader is able to see the days on which a team member is on leave or there is a official leave. 

The team leader has the authority to start the daily meeting by startint the WCF service and as soon as the server is started, the clients (team members) get a desktop notification popup to enter their application.

The dchat-Client has also a wondows form in which the user submits the task updates and provides description (ETA, resason for delay,etc)  for each task and submits it to the server. 

The Sever then has the facility to create different reports as required.


The purpose of this application or rather the advantage of this application over physical meetings is that, no physical location is required and updates are recorded for audit and reporting purpose.








