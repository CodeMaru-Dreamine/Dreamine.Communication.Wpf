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
/// 통신 상태와 메시지 로그를 표시하는 모니터 ViewModel입니다.
/// </summary>
public sealed class CommunicationMonitorViewModel : INotifyPropertyChanged
{
    private CommunicationChannelViewItem? _selectedChannel;

    /// <summary>
    /// CommunicationMonitorViewModel 클래스의 새 인스턴스를 초기화합니다.
    /// </summary>
    public CommunicationMonitorViewModel()
    {
        ClearLogsCommand = new DelegateCommand(_ => ClearLogs());
    }

    /// <summary>
    /// 속성 변경 시 발생합니다.
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// 통신 채널 목록입니다.
    /// </summary>
    public ObservableCollection<CommunicationChannelViewItem> Channels { get; } = new();

    /// <summary>
    /// 메시지 로그 목록입니다.
    /// </summary>
    public ObservableCollection<CommunicationMessageLogItem> Logs { get; } = new();

    /// <summary>
    /// 선택된 통신 채널입니다.
    /// </summary>
    public CommunicationChannelViewItem? SelectedChannel
    {
        get => _selectedChannel;
        set => SetProperty(ref _selectedChannel, value);
    }

    /// <summary>
    /// 로그 삭제 명령입니다.
    /// </summary>
    public ICommand ClearLogsCommand { get; }

    /// <summary>
    /// 통신 채널을 추가합니다.
    /// </summary>
    /// <param name="name">채널 이름입니다.</param>
    /// <param name="kind">전송 방식입니다.</param>
    /// <param name="description">채널 설명입니다.</param>
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
    /// 통신 채널 상태를 갱신합니다.
    /// </summary>
    /// <param name="name">채널 이름입니다.</param>
    /// <param name="state">변경할 연결 상태입니다.</param>
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
    /// 통신 채널 설명을 갱신합니다.
    /// </summary>
    /// <param name="name">채널 이름입니다.</param>
    /// <param name="description">변경할 채널 설명입니다.</param>
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
    /// 송신 메시지 로그를 추가합니다.
    /// </summary>
    /// <param name="channelName">채널 이름입니다.</param>
    /// <param name="kind">전송 방식입니다.</param>
    /// <param name="message">메시지입니다.</param>
    public void AddSendLog(string channelName, TransportKind kind, MessageEnvelope message)
    {
        AddMessageLog(channelName, kind, "SEND", message);
    }

    /// <summary>
    /// 수신 메시지 로그를 추가합니다.
    /// </summary>
    /// <param name="channelName">채널 이름입니다.</param>
    /// <param name="kind">전송 방식입니다.</param>
    /// <param name="message">메시지입니다.</param>
    public void AddReceiveLog(string channelName, TransportKind kind, MessageEnvelope message)
    {
        AddMessageLog(channelName, kind, "RECV", message);
    }

    /// <summary>
    /// 메시지 로그를 모두 삭제합니다.
    /// </summary>
    public void ClearLogs()
    {
        Logs.Clear();
    }

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