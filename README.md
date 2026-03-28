# Bekos.Tcp

**Bekos.Tcp** is a TCP networking library for .NET that provides a structured, event-driven communication layer between server and client applications.
The implementation is built around a generic message system, allowing any serializable type to serve as the message contract. Core networking logic is separated into a reusable library, accompanied by a demonstration application built with Windows Forms.

## Features

- **Generic server and client** — `TcpServer<T>` and `TcpClient<T>` with a custom `ITcpMessage<T>` interface for defining message contracts.
- **Non-generic variants** — simpler `TcpServer` and `TcpClient` available for basic use cases.
- **Event-driven architecture** — events for message reception, connection state changes, client connect/disconnect, and latency updates.
- **Buffered streaming** — transmits large messages reliably by reading and writing in configurable chunks.
- **Custom message headers** — validates incoming data using a configurable header string.
- **Configurable client limit** — set a maximum concurrent client count on the server.
- **Optional AES encryption** — point-to-point encryption of message content via a pluggable encryption layer.
- **Auto-reconnect** — client retries connection automatically at a configurable interval.
- **Windows Forms demo** — dual-pane demo app running both server and client simultaneously.

## Details

- Written in **C#**, targeting **.NET 10**.
- Uses **Windows Forms** for the demo application GUI.
- Structured as two projects: `Bekos.Tcp` (core library) and `Bekos.Tcp.Demo` (WinForms demo).
- Windows only.

## Dependencies

- [Encryption](https://github.com/BerkaySevinc/encryption) — provides the AES encryption layer used for optional message content encryption; included as a Git submodule under `libs/encryption`.
