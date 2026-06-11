using System.ComponentModel;
using System.Runtime.CompilerServices;
using Dreamine.Communication.Abstractions.Enums;

namespace Dreamine.Communication.Wpf.Models;

/// <summary>
/// 통신 채널 상태 표시용 모델입니다.
/// </summary>
public sealed class CommunicationChannelViewItem : INotifyPropertyChanged
{
    private string _name = string.Empty;
    private TransportKind _kind;
    private ConnectionState _state = ConnectionState.Disconnected;
    private string _description = string.Empty;

    /// <summary>
    /// 속성 변경 시 발생합니다.
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// 채널 이름입니다.
    /// </summary>
    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    /// <summary>
    /// 전송 방식입니다.
    /// </summary>
    public TransportKind Kind
    {
        get => _kind;
        set => SetProperty(ref _kind, value);
    }

    /// <summary>
    /// 연결 상태입니다.
    /// </summary>
    public ConnectionState State
    {
        get => _state;
        set => SetProperty(ref _state, value);
    }

    /// <summary>
    /// 채널 설명입니다.
    /// </summary>
    public string Description
    {
        get => _description;
        set => SetProperty(ref _description, value);
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