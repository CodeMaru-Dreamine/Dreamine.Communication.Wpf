using Dreamine.Communication.Abstractions.Enums;

namespace Dreamine.Communication.Wpf.Models;

/// <summary>
/// 통신 메시지 로그 표시용 모델입니다.
/// </summary>
public sealed class CommunicationMessageLogItem
{
    /// <summary>
    /// 로그 발생 시각입니다.
    /// </summary>
    public DateTimeOffset CreatedAt { get; init; } = DateTimeOffset.Now;

    /// <summary>
    /// 통신 채널 이름입니다.
    /// </summary>
    public string ChannelName { get; init; } = string.Empty;

    /// <summary>
    /// 전송 방식입니다.
    /// </summary>
    public TransportKind Kind { get; init; }

    /// <summary>
    /// 메시지 방향입니다.
    /// </summary>
    public string Direction { get; init; } = string.Empty;

    /// <summary>
    /// 메시지 이름입니다.
    /// </summary>
    public string MessageName { get; init; } = string.Empty;

    /// <summary>
    /// 메시지 라우트입니다.
    /// </summary>
    public string Route { get; init; } = string.Empty;

    /// <summary>
    /// Payload 크기입니다.
    /// </summary>
    public int PayloadLength { get; init; }

    /// <summary>
    /// 표시용 Payload 문자열입니다.
    /// </summary>
    public string PayloadPreview { get; init; } = string.Empty;
}