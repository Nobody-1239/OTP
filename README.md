# OTP
# 🔐 OTP Authentication System

A simple and secure project for generating and validating one-time passwords (OTP) using ASP.NET Core Razor Pages.

## 📌 Project Overview

This system implements OTP-based authentication with the following features:
- Generates a 6-digit random code
- Valid for 60 seconds
- Stores and validates OTP using Session
- Optional integration for email delivery

## ✨ Features

- Time-limited random OTP generation
- User input validation against stored OTP
- Status messages for success, error, and expiration
- Modular design with a dedicated `PaswordUtils` class
- Easily extendable for SMS or email delivery

## 🧰 Technologies Used

- ASP.NET Core 7+
- Razor Pages
- Session API
- C# (.NET)
- HTML/CSS (Bootstrap for styling)
