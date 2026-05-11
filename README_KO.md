# Dreamine.Communication.Wpf

`Dreamine.Communication.Wpf`는 Dreamine Communication 계열 패키지의 일부입니다.

이 패키지는 Dreamine Communication을 위한 WPF 전용 모니터링 및 진단 컴포넌트를 제공합니다.  
Core 통신 패키지들이 UI에 종속되지 않도록 기본 `Dreamine.Communication.FullKit` 패키지와 분리되어 있습니다.

[➡️ View English README](./README.md)

## Description

Dreamine Communication을 위한 WPF 모니터링 및 진단 컴포넌트입니다.

## 주요 기능

- WPF 통신 모니터 `UserControl`
- 통신 채널 상태 표시
- 메시지 송신/수신 로그 표시
- 연결 상태 시각 표시
- 기본 진단 ViewModel 기반 구조

## 주요 구성 요소

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

## 설계 원칙

- WPF UI 컴포넌트를 Core 통신 로직과 분리합니다.
- Sockets, Serial, RabbitMQ 같은 구체 전송 패키지를 직접 참조하지 않습니다.
- `Dreamine.Communication.Abstractions`와 `Dreamine.Communication.Core`에만 의존합니다.
- 단방향 의존성 흐름을 유지합니다.
- 이 패키지는 모니터링 및 진단 UI에만 집중합니다.

## 패키지 역할

```text
Dreamine.Communication.Abstractions
    ↑
Dreamine.Communication.Core
    ↑
Dreamine.Communication.Wpf
```

## 의존성

- `Dreamine.Communication.Abstractions`
- `Dreamine.Communication.Core`

## 대상 프레임워크

```text
net8.0-windows
```

## 참고

이 패키지는 `net8.0-windows`를 대상으로 하며 WPF를 사용합니다.

기본 `Dreamine.Communication.FullKit` 패키지에는 의도적으로 포함하지 않습니다.

## 관련 패키지

- `Dreamine.Communication.Abstractions`
- `Dreamine.Communication.Core`
- `Dreamine.Communication.Sockets`
- `Dreamine.Communication.Serial`
- `Dreamine.Communication.RabbitMQ`
- `Dreamine.Communication.FullKit`

## 라이선스

이 프로젝트는 MIT 라이선스를 따릅니다.
