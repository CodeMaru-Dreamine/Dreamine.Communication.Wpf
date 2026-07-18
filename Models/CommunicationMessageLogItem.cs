using Dreamine.Communication.Abstractions.Enums;

namespace Dreamine.Communication.Wpf.Models;

/// <summary>
/// \if KO
/// <para>WPF 화면에 표시할 통신 메시지 로그의 메타데이터와 페이로드 미리보기를 보관합니다.</para>
/// \endif
/// \if EN
/// <para>Stores communication-message log metadata and a payload preview for WPF display.</para>
/// \endif
/// </summary>
public sealed class CommunicationMessageLogItem
{
    /// <summary>
    /// \if KO
    /// <para>로그가 생성된 로컬 시각을 가져옵니다.</para>
    /// \endif
    /// \if EN
    /// <para>Gets the local time at which the log was created.</para>
    /// \endif
    /// </summary>
    public DateTimeOffset CreatedAt { get; init; } = DateTimeOffset.Now;

    /// <summary>
    /// \if KO
    /// <para>메시지를 송수신한 채널 이름을 가져옵니다.</para>
    /// \endif
    /// \if EN
    /// <para>Gets the name of the channel that sent or received the message.</para>
    /// \endif
    /// </summary>
    public string ChannelName { get; init; } = string.Empty;

    /// <summary>
    /// \if KO
    /// <para>메시지의 전송 방식을 가져옵니다.</para>
    /// \endif
    /// \if EN
    /// <para>Gets the message transport kind.</para>
    /// \endif
    /// </summary>
    public TransportKind Kind { get; init; }

    /// <summary>
    /// \if KO
    /// <para>송신 또는 수신 방향 표시를 가져옵니다.</para>
    /// \endif
    /// \if EN
    /// <para>Gets the send-or-receive direction label.</para>
    /// \endif
    /// </summary>
    public string Direction { get; init; } = string.Empty;

    /// <summary>
    /// \if KO
    /// <para>메시지의 논리적 이름을 가져옵니다.</para>
    /// \endif
    /// \if EN
    /// <para>Gets the logical message name.</para>
    /// \endif
    /// </summary>
    public string MessageName { get; init; } = string.Empty;

    /// <summary>
    /// \if KO
    /// <para>메시지 라우트를 가져옵니다.</para>
    /// \endif
    /// \if EN
    /// <para>Gets the message route.</para>
    /// \endif
    /// </summary>
    public string Route { get; init; } = string.Empty;

    /// <summary>
    /// \if KO
    /// <para>페이로드 크기(바이트)를 가져옵니다.</para>
    /// \endif
    /// \if EN
    /// <para>Gets the payload size in bytes.</para>
    /// \endif
    /// </summary>
    public int PayloadLength { get; init; }

    /// <summary>
    /// \if KO
    /// <para>화면 표시용 페이로드 미리보기를 가져옵니다.</para>
    /// \endif
    /// \if EN
    /// <para>Gets the payload preview for display.</para>
    /// \endif
    /// </summary>
    public string PayloadPreview { get; init; } = string.Empty;
}
