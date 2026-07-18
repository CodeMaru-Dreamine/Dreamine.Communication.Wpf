using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Dreamine.Communication.Abstractions.Enums;
using Dreamine.Communication.Abstractions.Models;
using Dreamine.Communication.Wpf.Commands;
using Dreamine.Communication.Wpf.Models;

namespace Dreamine.Communication.Wpf.ViewModels;

/// <summary>
/// \if KO
/// <para>통신 채널 상태와 송수신 메시지 로그를 WPF 바인딩에 제공하는 ViewModel입니다.</para>
/// \endif
/// \if EN
/// <para>Provides communication channel states and sent/received message logs for WPF binding.</para>
/// \endif
/// </summary>
public sealed class CommunicationMonitorViewModel : INotifyPropertyChanged
{
    /// <summary>
    /// \if KO
    /// <para>selected Channel 값을 보관합니다.</para>
    /// \endif
    /// \if EN
    /// <para>Stores the selected channel value.</para>
    /// \endif
    /// </summary>
    private CommunicationChannelViewItem? _selectedChannel;

    /// <summary>
    /// \if KO
    /// <para>로그 삭제 명령과 빈 채널·로그 컬렉션으로 ViewModel을 초기화합니다.</para>
    /// \endif
    /// \if EN
    /// <para>Initializes the view model with a clear-logs command and empty channel and log collections.</para>
    /// \endif
    /// </summary>
    public CommunicationMonitorViewModel()
    {
        ClearLogsCommand = new DelegateCommand(_ => ClearLogs());
    }

    /// <summary>
    /// \if KO
    /// <para>바인딩된 속성 값이 변경될 때 발생합니다.</para>
    /// \endif
    /// \if EN
    /// <para>Occurs when a bound property value changes.</para>
    /// \endif
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// \if KO
    /// <para>화면에 표시할 통신 채널 컬렉션을 가져옵니다.</para>
    /// \endif
    /// \if EN
    /// <para>Gets the communication-channel collection displayed by the view.</para>
    /// \endif
    /// </summary>
    public ObservableCollection<CommunicationChannelViewItem> Channels { get; } = new();

    /// <summary>
    /// \if KO
    /// <para>최신 항목이 앞에 배치되는 메시지 로그 컬렉션을 가져옵니다.</para>
    /// \endif
    /// \if EN
    /// <para>Gets the message-log collection with newest entries first.</para>
    /// \endif
    /// </summary>
    public ObservableCollection<CommunicationMessageLogItem> Logs { get; } = new();

    /// <summary>
    /// \if KO
    /// <para>현재 선택된 통신 채널을 가져오거나 설정합니다.</para>
    /// \endif
    /// \if EN
    /// <para>Gets or sets the currently selected communication channel.</para>
    /// \endif
    /// </summary>
    public CommunicationChannelViewItem? SelectedChannel
    {
        get => _selectedChannel;
        set => SetProperty(ref _selectedChannel, value);
    }

    /// <summary>
    /// \if KO
    /// <para>모든 메시지 로그를 삭제하는 명령을 가져옵니다.</para>
    /// \endif
    /// \if EN
    /// <para>Gets the command that clears all message logs.</para>
    /// \endif
    /// </summary>
    public ICommand ClearLogsCommand { get; }

    /// <summary>
    /// \if KO
    /// <para>같은 이름이 없는 경우 새 통신 채널을 추가합니다.</para>
    /// \endif
    /// \if EN
    /// <para>Adds a communication channel when no channel with the same name exists.</para>
    /// \endif
    /// </summary>
    /// <param name="name">
    /// \if KO
    /// <para>고유한 채널 이름입니다.</para>
    /// \endif
    /// \if EN
    /// <para>The unique channel name.</para>
    /// \endif
    /// </param>
    /// <param name="kind">
    /// \if KO
    /// <para>채널 전송 방식입니다.</para>
    /// \endif
    /// \if EN
    /// <para>The channel transport kind.</para>
    /// \endif
    /// </param>
    /// <param name="description">
    /// \if KO
    /// <para>선택적 채널 설명입니다.</para>
    /// \endif
    /// \if EN
    /// <para>The optional channel description.</para>
    /// \endif
    /// </param>
    /// <exception cref="ArgumentException">
    /// \if KO
    /// <para>이름이 비어 있는 경우 발생합니다.</para>
    /// \endif
    /// \if EN
    /// <para>Thrown when the name is empty.</para>
    /// \endif
    /// </exception>
    public void AddChannel(string name, TransportKind kind, string description = "")
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        if (Channels.Any(x => x.Name == name))
        {
            return;
        }

        Channels.Add(new CommunicationChannelViewItem
        {
            Name = name,
            Kind = kind,
            State = ConnectionState.Disconnected,
            Description = description
        });
    }

    /// <summary>
    /// \if KO
    /// <para>지정한 이름의 채널이 있으면 연결 상태를 갱신합니다.</para>
    /// \endif
    /// \if EN
    /// <para>Updates the connection state when a channel with the specified name exists.</para>
    /// \endif
    /// </summary>
    /// <param name="name">
    /// \if KO
    /// <para>찾을 채널 이름입니다.</para>
    /// \endif
    /// \if EN
    /// <para>The channel name to find.</para>
    /// \endif
    /// </param>
    /// <param name="state">
    /// \if KO
    /// <para>설정할 연결 상태입니다.</para>
    /// \endif
    /// \if EN
    /// <para>The connection state to set.</para>
    /// \endif
    /// </param>
    public void UpdateChannelState(string name, ConnectionState state)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        var channel = Channels.FirstOrDefault(x => x.Name == name);

        if (channel is null)
        {
            return;
        }

        channel.State = state;
    }

    /// <summary>
    /// \if KO
    /// <para>지정한 이름의 채널이 있으면 설명을 갱신합니다.</para>
    /// \endif
    /// \if EN
    /// <para>Updates the description when a channel with the specified name exists.</para>
    /// \endif
    /// </summary>
    /// <param name="name">
    /// \if KO
    /// <para>찾을 채널 이름입니다.</para>
    /// \endif
    /// \if EN
    /// <para>The channel name to find.</para>
    /// \endif
    /// </param>
    /// <param name="description">
    /// \if KO
    /// <para>설정할 설명이며 <see langword="null"/>이면 빈 문자열입니다.</para>
    /// \endif
    /// \if EN
    /// <para>The description to set; <see langword="null"/> becomes an empty string.</para>
    /// \endif
    /// </param>
    public void UpdateChannelDescription(string name, string description)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        var channel = Channels.FirstOrDefault(x => x.Name == name);

        if (channel is null)
        {
            return;
        }

        channel.Description = description ?? string.Empty;
    }

    /// <summary>
    /// \if KO
    /// <para>송신 방향의 메시지 로그를 컬렉션 앞에 추가합니다.</para>
    /// \endif
    /// \if EN
    /// <para>Adds a sent-message log to the front of the collection.</para>
    /// \endif
    /// </summary>
    /// <param name="channelName">
    /// \if KO
    /// <para>송신 채널 이름입니다.</para>
    /// \endif
    /// \if EN
    /// <para>The sending channel name.</para>
    /// \endif
    /// </param>
    /// <param name="kind">
    /// \if KO
    /// <para>전송 방식입니다.</para>
    /// \endif
    /// \if EN
    /// <para>The transport kind.</para>
    /// \endif
    /// </param>
    /// <param name="message">
    /// \if KO
    /// <para>기록할 송신 메시지입니다.</para>
    /// \endif
    /// \if EN
    /// <para>The sent message to log.</para>
    /// \endif
    /// </param>
    public void AddSendLog(string channelName, TransportKind kind, MessageEnvelope message)
    {
        AddMessageLog(channelName, kind, "SEND", message);
    }

    /// <summary>
    /// \if KO
    /// <para>수신 방향의 메시지 로그를 컬렉션 앞에 추가합니다.</para>
    /// \endif
    /// \if EN
    /// <para>Adds a received-message log to the front of the collection.</para>
    /// \endif
    /// </summary>
    /// <param name="channelName">
    /// \if KO
    /// <para>수신 채널 이름입니다.</para>
    /// \endif
    /// \if EN
    /// <para>The receiving channel name.</para>
    /// \endif
    /// </param>
    /// <param name="kind">
    /// \if KO
    /// <para>전송 방식입니다.</para>
    /// \endif
    /// \if EN
    /// <para>The transport kind.</para>
    /// \endif
    /// </param>
    /// <param name="message">
    /// \if KO
    /// <para>기록할 수신 메시지입니다.</para>
    /// \endif
    /// \if EN
    /// <para>The received message to log.</para>
    /// \endif
    /// </param>
    public void AddReceiveLog(string channelName, TransportKind kind, MessageEnvelope message)
    {
        AddMessageLog(channelName, kind, "RECV", message);
    }

    /// <summary>
    /// \if KO
    /// <para>메시지 로그 컬렉션의 모든 항목을 삭제합니다.</para>
    /// \endif
    /// \if EN
    /// <para>Removes every entry from the message-log collection.</para>
    /// \endif
    /// </summary>
    public void ClearLogs()
    {
        Logs.Clear();
    }

    /// <summary>
    /// \if KO
    /// <para>메시지 메타데이터와 UTF-8 미리보기를 생성해 로그 컬렉션 앞에 삽입합니다.</para>
    /// \endif
    /// \if EN
    /// <para>Creates message metadata and a UTF-8 preview and inserts the log at the front.</para>
    /// \endif
    /// </summary>
    /// <param name="channelName">
    /// \if KO
    /// <para>채널 이름입니다.</para>
    /// \endif
    /// \if EN
    /// <para>The channel name.</para>
    /// \endif
    /// </param>
    /// <param name="kind">
    /// \if KO
    /// <para>전송 방식입니다.</para>
    /// \endif
    /// \if EN
    /// <para>The transport kind.</para>
    /// \endif
    /// </param>
    /// <param name="direction">
    /// \if KO
    /// <para>송수신 방향 표시입니다.</para>
    /// \endif
    /// \if EN
    /// <para>The send-or-receive direction label.</para>
    /// \endif
    /// </param>
    /// <param name="message">
    /// \if KO
    /// <para>로그로 변환할 메시지입니다.</para>
    /// \endif
    /// \if EN
    /// <para>The message to convert into a log entry.</para>
    /// \endif
    /// </param>
    private void AddMessageLog(
        string channelName,
        TransportKind kind,
        string direction,
        MessageEnvelope message)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(channelName);
        ArgumentNullException.ThrowIfNull(message);

        Logs.Insert(0, new CommunicationMessageLogItem
        {
            ChannelName = channelName,
            Kind = kind,
            Direction = direction,
            MessageName = message.Name,
            Route = message.Route,
            PayloadLength = message.Payload.Length,
            PayloadPreview = CreatePayloadPreview(message.Payload)
        });
    }

    /// <summary>
    /// \if KO
    /// <para>UTF-8 페이로드를 최대 120자로 잘라 화면 표시용 미리보기를 생성합니다.</para>
    /// \endif
    /// \if EN
    /// <para>Creates a display preview by decoding UTF-8 payload and truncating it to 120 characters.</para>
    /// \endif
    /// </summary>
    /// <param name="payload">
    /// \if KO
    /// <para>미리보기로 변환할 바이트입니다.</para>
    /// \endif
    /// \if EN
    /// <para>The bytes to convert into a preview.</para>
    /// \endif
    /// </param>
    /// <returns>
    /// \if KO
    /// <para>비어 있거나 잘린 UTF-8 문자열입니다.</para>
    /// \endif
    /// \if EN
    /// <para>An empty or truncated UTF-8 string.</para>
    /// \endif
    /// </returns>
    private static string CreatePayloadPreview(byte[] payload)
    {
        if (payload.Length == 0)
        {
            return string.Empty;
        }

        var text = Encoding.UTF8.GetString(payload);

        if (text.Length <= 120)
        {
            return text;
        }

        return text[..120] + "...";
    }

    /// <summary>
    /// \if KO
    /// <para>값이 변경된 경우에만 저장소를 갱신하고 속성 변경 이벤트를 발생시킵니다.</para>
    /// \endif
    /// \if EN
    /// <para>Updates storage and raises property change only when the value changes.</para>
    /// \endif
    /// </summary>
    /// <typeparam name="T">
    /// \if KO
    /// <para>속성 값 형식입니다.</para>
    /// \endif
    /// \if EN
    /// <para>The property value type.</para>
    /// \endif
    /// </typeparam>
    /// <param name="storage">
    /// \if KO
    /// <para>후방 저장소입니다.</para>
    /// \endif
    /// \if EN
    /// <para>The backing storage.</para>
    /// \endif
    /// </param>
    /// <param name="value">
    /// \if KO
    /// <para>새 값입니다.</para>
    /// \endif
    /// \if EN
    /// <para>The new value.</para>
    /// \endif
    /// </param>
    /// <param name="propertyName">
    /// \if KO
    /// <para>변경된 속성 이름입니다.</para>
    /// \endif
    /// \if EN
    /// <para>The changed property name.</para>
    /// \endif
    /// </param>
    private void SetProperty<T>(
        ref T storage,
        T value,
        [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(storage, value))
        {
            return;
        }

        storage = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
