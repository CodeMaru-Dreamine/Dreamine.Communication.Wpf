# Dreamine.Communication.Wpf

`Dreamine.Communication.Wpf`는 Dreamine Communication 계열 패키지의 일부입니다.

이 패키지는 Dreamine Communication의 WPF 전용 모니터링 및 진단 계층을 제공합니다. Core 계열 패키지를 UI 비종속으로 유지하기 위해 기본 FullKit과 분리되어 있습니다.

[➡️ English Version](README.md)

## Description

WPF monitoring and diagnostic components for Dreamine Communication.

## 주요 기능

- WPF 모니터링 경계
- 통신 상태 표시 기반
- 메시지 검사 UI 기반
- 진단 컴포넌트 경계

## 설계 원칙

- 구체 통신 구현체를 상위 레이어와 분리합니다.
- `Dreamine.Communication.Abstractions`의 계약에 의존합니다.
- 패키지 책임을 작고 명확하게 유지합니다.
- 단방향 의존성 흐름을 유지합니다.
- 향후 어댑터를 추가해도 애플리케이션 로직을 변경하지 않도록 합니다.

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

이 패키지는 net8.0-windows를 대상으로 하며 WPF를 사용합니다.

## 관련 패키지

- `Dreamine.Communication.Abstractions`
- `Dreamine.Communication.Core`
- `Dreamine.Communication.Sockets`
- `Dreamine.Communication.Serial`
- `Dreamine.Communication.RabbitMQ`
- `Dreamine.Communication.FullKit`
- `Dreamine.Communication.Wpf`

## 라이선스

이 프로젝트는 MIT 라이선스를 따릅니다.
