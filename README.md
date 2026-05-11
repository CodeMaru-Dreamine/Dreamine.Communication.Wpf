# Dreamine.Communication.Wpf

`Dreamine.Communication.Wpf` is part of the Dreamine Communication package family.

This package provides the WPF-specific monitoring and diagnostic layer for Dreamine Communication. It is separated from the default FullKit to keep the core packages UI-independent.

[➡️ 한국어 문서 보기](./README_KO.md)

## Description

WPF monitoring and diagnostic components for Dreamine Communication.

## Features

- WPF monitoring boundary
- Communication state display foundation
- Message inspection UI foundation
- Diagnostic component boundary

## Design Principles

- Keep concrete transport implementations isolated from upper layers.
- Depend on `Dreamine.Communication.Abstractions` contracts.
- Keep package responsibilities small and explicit.
- Preserve one-way dependency flow.
- Allow future adapters to be added without changing application logic.

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

This package targets net8.0-windows and uses WPF.

## Related Packages

- `Dreamine.Communication.Abstractions`
- `Dreamine.Communication.Core`
- `Dreamine.Communication.Sockets`
- `Dreamine.Communication.Serial`
- `Dreamine.Communication.RabbitMQ`
- `Dreamine.Communication.FullKit`
- `Dreamine.Communication.Wpf`

## License

This project is licensed under the MIT License.
