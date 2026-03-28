A TCP networking library for .NET that provides a structured, event-driven communication layer between server and client applications. The implementation is built around a generic message system, allowing any serializable type to serve as the message contract. It separates core networking logic into a reusable library, accompanied by a demonstration application built with Windows Forms.

- Generic `TcpServer<T>` and `TcpClient<T>` with a custom `ITcpMessage<T>` interface for defining message contracts
- Non-generic variants available for simpler use cases
- Event-driven architecture with events for message reception, connection state changes, client connect/disconnect, and latency updates
- Buffered streaming for transmitting large messages reliably across the network
- Custom message header support for identifying and validating incoming data
- Configurable maximum client count on the server
- Optional point-to-point AES encryption for message content
- Auto-reconnect support on the client with a configurable retry interval
- Includes a dual-pane Windows Forms demo application running both server and client simultaneously

## Dependencies

- [Encryption](https://github.com/BerkaySevinc/encryption) — provides the AES encryption layer used for optional message content encryption; included as a Git submodule under `libs/encryption`
