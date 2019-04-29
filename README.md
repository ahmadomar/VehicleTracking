# Vehicle Tracking System

## Introduction

Here I am implementing Vehicle Tracking System using some of the technologies to let the clients view Vehicle status may be Connected or Disconnected, also fixed the problem using Microservice architecture.

## Scenario

- They have a number of connected vehicles that belongs to a number of customers.
- They have a need to be able to view the status of the connection among these vehicles on a monitoring display.
- The vehicles send the status of the connection one time per minute.
- The status can be compared with a ping (network trace); no request from the vehicle means no connection.
- So, vehicle is either Connected or Disconnected.

## Requirements

- Microsoft Visual Studio 2017
- .NET Core 2.2
- RabbitMQ

## Technologies

- .NET Core & ASP.NET Core MVC
- ASP.NET Core SignalR
- In-Memory Database
- EntityFramework Core
- RawRabbit 1.10.4

## Full architectural

![alt Architectural](files/VehicleArchitecture.png)

## Solution Analysis

![alt Analysis](files/SolutionAnalysis.png)

## Setup

## Online Demo