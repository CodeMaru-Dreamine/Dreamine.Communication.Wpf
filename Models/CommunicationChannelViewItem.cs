using System.ComponentModel;
using System.Runtime.CompilerServices;
using Dreamine.Communication.Abstractions.Enums;

namespace Dreamine.Communication.Wpf.Models;

/// <summary>
/// \if KO
/// <para>WPF 화면에 표시할 통신 채널의 이름, 전송 방식, 상태 및 설명을 보관합니다.</para>
/// \endif
/// \if EN
/// <para>Stores the name, transport kind, state, and description of a communication channel for WPF display.</para>
/// \endif
/// </summary>
public sealed class CommunicationChannelViewItem : INotifyPropertyChanged
{
    /// <summary>
    /// \if KO
    /// <para>name 값을 보관합니다.</para>
    /// \endif
    /// \if EN
    /// <para>Stores the name value.</para>
    /// \endif
    /// </summary>
    private string _name = string.Empty;
    /// <summary>
    /// \if KO
    /// <para>kind 값을 보관합니다.</para>
    /// \endif
    /// \if EN
    /// <para>Stores the kind value.</para>
    /// \endif
    /// </summary>
    private TransportKind _kind;
    /// <summary>
    /// \if KO
    /// <para>state 값을 보관합니다.</para>
    /// \endif
    /// \if EN
    /// <para>Stores the state value.</para>
    /// \endif
    /// </summary>
    private ConnectionState _state = ConnectionState.Disconnected;
    /// <summary>
    /// \if KO
    /// <para>description 값을 보관합니다.</para>
    /// \endif
    /// \if EN
    /// <para>Stores the description value.</para>
    /// \endif
    /// </summary>
    private string _description = string.Empty;

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
    /// <para>채널 표시 이름을 가져오거나 설정합니다.</para>
    /// \endif
    /// \if EN
    /// <para>Gets or sets the channel display name.</para>
    /// \endif
    /// </summary>
    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    /// <summary>
    /// \if KO
    /// <para>채널의 전송 방식을 가져오거나 설정합니다.</para>
    /// \endif
    /// \if EN
    /// <para>Gets or sets the channel transport kind.</para>
    /// \endif
    /// </summary>
    public TransportKind Kind
    {
        get => _kind;
        set => SetProperty(ref _kind, value);
    }

    /// <summary>
    /// \if KO
    /// <para>채널의 현재 연결 상태를 가져오거나 설정합니다.</para>
    /// \endif
    /// \if EN
    /// <para>Gets or sets the current channel connection state.</para>
    /// \endif
    /// </summary>
    public ConnectionState State
    {
        get => _state;
        set => SetProperty(ref _state, value);
    }

    /// <summary>
    /// \if KO
    /// <para>채널 설명을 가져오거나 설정합니다.</para>
    /// \endif
    /// \if EN
    /// <para>Gets or sets the channel description.</para>
    /// \endif
    /// </summary>
    public string Description
    {
        get => _description;
        set => SetProperty(ref _description, value);
    }

    /// <summary>
    /// \if KO
    /// <para>값이 실제로 변경된 경우에만 저장소를 갱신하고 속성 변경 이벤트를 발생시킵니다.</para>
    /// \endif
    /// \if EN
    /// <para>Updates storage and raises property change only when the value actually changes.</para>
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
    /// <para>속성의 후방 저장소입니다.</para>
    /// \endif
    /// \if EN
    /// <para>The property backing storage.</para>
    /// \endif
    /// </param>
    /// <param name="value">
    /// \if KO
    /// <para>설정할 새 값입니다.</para>
    /// \endif
    /// \if EN
    /// <para>The new value to set.</para>
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
