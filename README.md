IoT Workshop @TechHub
=====================


About
-----

The goal of this workshop is to get people working with the IoT services from Microsoft Azure and to see how to integrate them with various operating systems and programming languages. There sessions presented will consist of a demo, accompanied by a step-by-step tutorial both on Windows + Visual Studio + C# + Windows IoT Core (on a Raspberry Pi 3) and Mac/Ubuntu + NodeJS/Python + Raspbian (on a Raspberry Pi 3).

For the duration of the workshop, we will provide Raspberry Pi 3 boards with Windows 10 IoT Core installed, but you can come with your own board or with Raspbian on a MicroSD card.

Prerequisites
-------------
The workshop assumes basic programming skills in C# or NodeJS/Python and will not cover basic language features.
Every session will try to develop similar functionality for both tracks (Windows 10 IoT and Raspbian), but there may be slight differences between the C# and NodeJS/Python applications.


Session 1 - Getting your development environment ready
-------------------------------------------------------

In order to get started, you need to configure your development environment. There are two tracks available for this workshop: 

- Windows + Visual Studio + C# + Windows IoT Core for  Raspberry Pi 3 - [detailed installation process here](link-to-Windows-track-installation-process)
- Mac/Ubuntu + NodeJS/Python + Raspbian for Raspberry Pi 3 - [detailed installation process here](link-to-Raspbian-installation-process)

> Please note that if your enviromnent of choice is Windows + Visual Studio + C# + Windows IoT Core for  Raspberry Pi 3, the installation process can be time consuming and is recommended that you do this step prior to the workshop.

Afer we have installed the laptop and Raspberry requirements, we also need an Azure subscription. We will use a Microsoft Azure Pass (without the need for a credit card) with a code and your Microsoft Account.

[This video tutorial shows how to activate your Azure Pass subscription](https://channel9.msdn.com/Blogs/joeraio/Activating-Microsoft-Azure-Subscription-Using-Azure-Pass).

> You can [find more information about the Microsoft Azure Pass here](https://azure.microsoft.com/en-gb/offers/azure-pass/).

At this point, we can test our development environment by running the Blinky LED application on [Windows](link-to-blinky-led-windows) or on [Raspbian](link-to-blinky-led-raspbian).


[Session 2 - Getting started with Azure and deploying Azure IoT Hub](link-to-session-2)
---------------------------------------------------------------------------------------
In this session we will get familiar with the Azure portal and what services are offered and we will deploy an Azure IoT Hub.
We will also get started with the Azure Command Line and we will register the Raspberry Pi with our Hub.

Session 3 - Send Device-to-Cloud messages
-----------------------------------------
In this session we will send the data from our Raspberry to the IoT Hub.

[For Windows, follow this tutorial](link-to-windows-tutorial)
[For Raspbian follow this tutorial](link-to-raspbian-tutorial).

Session 4 - Send Cloud-to-Device messages/commands
--------------------------------------------------
In this session we will send messages and commands from the Cloud (through IoT Hub) to our Raspberry Pi.

[For Windows, follow this tutorial](link-to-windows-tutorial)
[For Raspbian follow this tutorial](link-to-raspbian-tutorial).

[Session 5 - Sending data to Azure Stream Analytics](link-to-session-5)
--------------------------------------------------
We will take a look at Azure Stream Analytics and we will send data from IoT Hub --> Stream Analytics --> SQL database, Message Bus, Azure Storage and other services


Session 6 - Demo of intelligent bot that sends messages and commands to the device
----------------------------------------------------------------------------------

Session 7 - Demo of Xamarin application that sends messages and commands to the device
---------------------------------------------------------------------------------------