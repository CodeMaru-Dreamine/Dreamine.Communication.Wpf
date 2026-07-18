using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using Dreamine.Communication.Abstractions.Enums;

namespace Dreamine.Communication.Wpf.Converters;

/// <summary>
/// \if KO
/// <para>통신 연결 상태를 WPF 상태 표시 색상 Brush로 변환합니다.</para>
/// \endif
/// \if EN
/// <para>Converts communication connection states into WPF status brushes.</para>
/// \endif
/// </summary>
public sealed class ConnectionStateBrushConverter : IValueConverter
{
    /// <summary>
    /// \if KO
    /// <para>연결 상태를 의미에 맞는 WPF Brush로 변환합니다.</para>
    /// \endif
    /// \if EN
    /// <para>Converts a connection state to a semantically appropriate WPF brush.</para>
    /// \endif
    /// </summary>
    /// <param name="value">
    /// \if KO
    /// <para>변환할 연결 상태 값입니다.</para>
    /// \endif
    /// \if EN
    /// <para>The connection-state value to convert.</para>
    /// \endif
    /// </param>
    /// <param name="targetType">
    /// \if KO
    /// <para>바인딩 대상 형식이며 이 구현에서는 사용하지 않습니다.</para>
    /// \endif
    /// \if EN
    /// <para>The binding target type; it is not used.</para>
    /// \endif
    /// </param>
    /// <param name="parameter">
    /// \if KO
    /// <para>선택적 변환 매개변수이며 사용하지 않습니다.</para>
    /// \endif
    /// \if EN
    /// <para>The optional converter parameter; it is not used.</para>
    /// \endif
    /// </param>
    /// <param name="culture">
    /// \if KO
    /// <para>변환 문화권이며 사용하지 않습니다.</para>
    /// \endif
    /// \if EN
    /// <para>The conversion culture; it is not used.</para>
    /// \endif
    /// </param>
    /// <returns>
    /// \if KO
    /// <para>상태 표시용 Brush이며, 알 수 없는 값은 회색입니다.</para>
    /// \endif
    /// \if EN
    /// <para>A status brush; unknown values produce gray.</para>
    /// \endif
    /// </returns>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not ConnectionState state)
        {
            return Brushes.Gray;
        }

        return state switch
        {
            ConnectionState.Connected => Brushes.ForestGreen,
            ConnectionState.Listening => Brushes.ForestGreen,
            ConnectionState.Connecting => Brushes.DarkOrange,
            ConnectionState.Disconnecting => Brushes.DarkOrange,
            ConnectionState.Faulted => Brushes.Firebrick,
            ConnectionState.Disconnected => Brushes.Gray,
            _ => Brushes.Gray
        };
    }

    /// <summary>
    /// \if KO
    /// <para>역변환을 지원하지 않고 바인딩 무시 결과를 반환합니다.</para>
    /// \endif
    /// \if EN
    /// <para>Does not support reverse conversion and returns the binding no-op result.</para>
    /// \endif
    /// </summary>
    /// <param name="value">
    /// \if KO
    /// <para>역변환 입력이며 사용하지 않습니다.</para>
    /// \endif
    /// \if EN
    /// <para>The reverse-conversion input; it is not used.</para>
    /// \endif
    /// </param>
    /// <param name="targetType">
    /// \if KO
    /// <para>대상 형식이며 사용하지 않습니다.</para>
    /// \endif
    /// \if EN
    /// <para>The target type; it is not used.</para>
    /// \endif
    /// </param>
    /// <param name="parameter">
    /// \if KO
    /// <para>변환 매개변수이며 사용하지 않습니다.</para>
    /// \endif
    /// \if EN
    /// <para>The converter parameter; it is not used.</para>
    /// \endif
    /// </param>
    /// <param name="culture">
    /// \if KO
    /// <para>문화권이며 사용하지 않습니다.</para>
    /// \endif
    /// \if EN
    /// <para>The culture; it is not used.</para>
    /// \endif
    /// </param>
    /// <returns>
    /// \if KO
    /// <para><see cref="Binding.DoNothing"/>입니다.</para>
    /// \endif
    /// \if EN
    /// <para><see cref="Binding.DoNothing"/>.</para>
    /// \endif
    /// </returns>
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return Binding.DoNothing;
    }
}
