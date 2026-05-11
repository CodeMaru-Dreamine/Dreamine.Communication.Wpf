# Dreamine.Communication.Wpf

`Dreamine.Communication.Wpf` is part of the Dreamine Communication package family.

This package provides WPF-specific monitoring and diagnostic components for Dreamine Communication.  
It is separated from the default `Dreamine.Communication.FullKit` package to keep the core communication packages UI-independent.

[➡️ 한국어 문서 보기](./README_KO.md)

## Description

WPF monitoring and diagnostic components for Dreamine Communication.

## Features

- WPF communication monitor `UserControl`
- Communication channel state display
- Message send/receive log display
- Connection state visual indicator
- Basic diagnostic view model foundation

## Main Components

### Views

- `CommunicationMonitorView`

### ViewModels

- `CommunicationMonitorViewModel`

### Models

- `CommunicationChannelViewItem`
- `CommunicationMessageLogItem`

### Converters

- `ConnectionStateBrushConverter`

### Commands

- `DelegateCommand`

## Design Principles

- Keep WPF UI components separated from core communication logic.
- Do not reference concrete transport packages such as Sockets, Serial, or RabbitMQ.
- Depend only on `Dreamine.Communication.Abstractions` and `Dreamine.Communication.Core`.
- Preserve one-way dependency flow.
- Keep this package focused on monitoring and diagnostics UI.

## Package Role

```text
Dreamine.Communication.Abstractions
    ↑
Dreamine.Communication.Core
    ↑
Dreamine.Communication.Wpf
```

## Dependencies

- `Dreamine.Communication.Abstractions`
- `Dreamine.Communication.Core`

## Target Framework

```text
net8.0-windows
```

## Note

This package targets `net8.0-windows` and uses WPF.

It is intentionally excluded from the default `Dreamine.Communication.FullKit` package.

## Related Packages

- `Dreamine.Communication.Abstractions`
- `Dreamine.Communication.Core`
- `Dreamine.Communication.Sockets`
- `Dreamine.Communication.Serial`
- `Dreamine.Communication.RabbitMQ`
- `Dreamine.Communication.FullKit`

## License

This project is licensed under the MIT License.
