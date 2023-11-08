# Wazuh Agent Installer
## Usage
This application is used for the installation and modification of your Wazuh Agent. You will be guided through the installation of the agent and will be able to verify a successful connection to your Wazuh manager. In case of an unsuccessful connection, the application allows for agent uninstallation or providing new connection parameters. Authentication with the Wazuh manager uses a single use encrypted message on port 1515 and logs are forwarded after on port 1514.
## Troubleshooting
#### Files not found
This application expects to find the files it was bundled with in the same directory. Please unzip the archive into a separate folder and retry.
#### Reinstallation
If you are reinstalling, a new key and cert must be used. A new install bundle must be generated on the Wazuh manager.
#### Failed Uninstall
If removing the agent fails, it can be manually removed:
 - Type Windows + r to bring up the run window
 - Type in `appwiz.cpl` and hit enter
 - Find and right click `Wazuh Agent`
 - Click `Uninstall`
