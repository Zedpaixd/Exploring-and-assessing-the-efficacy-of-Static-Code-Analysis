# Exploring and analyzing the efficacy of Static Code Analysis

## Disclaimer

This guidance file does not go over all use cases of the following tools, but rather gives a quick introduction over how to set them up for their most popular use.

Moreover, given the fact that most compilers nowadays have a built-in linter that performs well, this guidance document is going to help you set up only the vulnerability detection tools.


## Vulnerabilities and Threat samples

They can be found by following the link provided below. User discretion is advised as most threats found in there can cause serious and permanent damage to your system.

**Repository:** 
https://github.com/Zedpaixd/Exploring-and-assessing-the-efficacy-of-Static-Code-Analysis



# SonarQube

#### SonarQube:   (https://www.sonarsource.com/products/sonarqube/)

By following the link from above, a download button can be seen which will offer multiple options. For this particular set of tests, the community edition was used (the free version), which while not have the highest detectability percentage, it is still enough to help one get a grasp of its functionality. To start it, you will need to navigate to the following path:

```.../community edition/bin/%your OS%/ ``` and run "**sonar.sh**"

Running that will now open a local server which can be accessed by going on **localhost:9000**.

Opening that will require you to log in with the "admin" "admin" credentials, followed by requiring a password change. After changing it, you will be met with a github-like page where you can create a new project.

To create a new project we will be required to press "Create Project" on the top right, followed by giving it a display name. After continuing, you may choose whether you wish to integrate it with your CI or test locally. For the sake of these tests, the analysis will be done locally, so we will select that one.

From there, we will be required to create a token for the project and the process is self explanatory from there on.

To run the test, you will have to add **SonarScanner** to the environment path of the system. This can be downloaded from **https://docs.sonarqube.org/9.8/analyzing-source-code/scanners/sonarscanner/** at the top of the page. Once selecting your OS, the download will start. 

After downloading, unzip and copy the path of the bin folder of the app to the system environment paths. 

To do that we will first need to copy the path to the bin folder of the app. This will typically look like this:

```...\sonar-scanner-4.8.0.2856-windows\bin ```
*^ you will want to copy that path and look to add it to the environment variable, such that it can be accessed from anywhere*

For windows you may achieve that by opening the system properties -> environment variables -> system variables -> Path -> Edit -> New -> Copy paste the path here

Once done, you will be able to run the following code in the project's folder:

sonar-scanner.bat -D"sonar.projectKey=**PROJECT_KEY**" -D"sonar.sources=." -D"sonar.host.url=http://localhost:9000" -D"sonar.token=**TOKEN**"

> PROJECT_KEY will represent the name of your project
> TOKEN is the token you were given before.

**!This is CaSe SeNsItIvE!**

Additional note: For compiling python code, you will need to specity the python version too. This is done by adding -D"sonar.python.version=VERSION" at the end of the command specified above which is used for scanning a project

*... where VERSION should be replaced by either 2 for python2 or 3 for python3*

Here is a succesful test: https://prnt.sc/ntaw-vkstUkW



# PVS-Studio
                                                        


#### PVS Studio:  (https://pvs-studio.com/en/pvs-studio/)

Download link is on the same page, just below. Select platform, main language and distribution format. 

Following that, run the installer and follow the prompts. 

Before concluding the set up, you will be requested to input your company email address -- this is for you to be sent a 7 day trial code.

The generic license is not going to be too useful, we are looking into getting more than just the "team" alternative.

After receiving the code, you will be requested to input it. If it is not possible, you may also do it via command prompt by running the following commands:

- **cd** PATH
> where PATH should be replaced by the path to where you can find the tool
> This is done such that we can run executables or files within the folder without adding them to the path

------
### Windows
- **PVS-Studio_Cmd.exe credentials --userName** %USER_NAME% **--licenseKey** %LICENSE_KEY%
> where USER_NAME will be your username and LICENSE_KEY the key you have received on your email
> This is an alternate way to activate the tool

----------
### Linux / Mac

- **pvs-studio-analyzer credentials**${USER_NAME} ${LICENSE_KEY}
> where USER_NAME will be your username and LICENSE_KEY the key you have received on your email
> This is an alternate way to activate the tool
----------
Once set up, you can open your app to write code in of choice, and typically under extensions you will have PVS-Studio. 

In the case of Visual Studio, on top under "Extensions" you will find "PVS-Studio", from where you can choose to analyse your code.

https://prnt.sc/OjtWhUqmcG61 - This is how a sample error should look like.










# SnykCode

#### SnykCode: (https://snyk.io/product/snyk-code/)

SnykCode is a special one in this list. This is not only because it can run on multiple ways and instances *(e.g. both on the website and in code editors such as VS Code, hereby allowing CI/CD)*, but also accepts github repositories as the input method for projects.

As a free user you are able to make use of most of the features of this app. Similarly, you can also use it on a very large scale projects too, just from a single GitHub repository.

To start, once you're on the starting page, you have the Start Free button. From there you press that and you log in with either Google or GitHub.

From there on you'll have countless options on how to progress. I have personally chosen GitHub and I just link repositories to the actual static code analysis tool.

If upon selecting a project it tells you that there has been some issues, that is perfectly fine. It means that the tool has accepted the project and the analysis has started. Give it between 5 to 10 minutes for larger scale projects or less for smaller scale ones so it can finish the scan and do not try to scan multiple projects at once - rather keep it at only one at a time.

Once it is done, you're going to get a website notification together with an e-mail notification saying that your project is ready. There is no need to run any code of executables, nor to download and install any sort of third party software.

Lastly, SnykCode also allows integrations with various various other tools such as GitHub, GitLab, Docker Hub, Kubernetes, Digital Ocean and all Jetbrains software. You can even configure it for slack to notify once a review has been finished.


This is how a final scan should look like https://prnt.sc/z5ECuUBV2-5Y



# Embold
                                       
                                       
#### Embold: (https://codequality.browserstack.com/auth)

Recently acquired by Browser Stack, Embold is also one of the static code analysis tools that we are going to be using. To start, you'll have to head to the link provided above and sign in with Google or just create a new account.

After logging in, you will be presented with the managed Organization screens where you're going to be able to choose from your GitHub, Bitbucket, GitLab or your Azure DevOps accounts.

After choosing the platform, you will have to log in that specific platform and give the rights to embold to read and possibly edit some of the repositories.Subsequently, after doing that, you will be presented with a screen where you'll have to choose your pricing. For these tests, the free license will be used.

Once the linking is done, you will be presented all your GitHub repositories that unbolt has access to.

From here on you just choose the repositories that you want Embold to scan and afterwards simply just wait for the scan to finish. This scan is going to showcase how many issues you have, what kind of anti patterns or code duplications and similarly you'll get a rating for your code.



# Codiga

Unfortunately, Codiga has stopped it services on 4th of May 2023. The testing has been done prior to those events, however, as of now, there is no possibility of installing and using Codiga.

https://www.codiga.io/blog/codiga-joins-datadog/
