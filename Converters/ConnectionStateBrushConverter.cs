using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using Dreamine.Communication.Abstractions.Enums;

namespace Dreamine.Communication.Wpf.Converters;

/// <summary>
/// ConnectionState를 상태 표시용 Brush로 변환합니다.
/// </summary>
public sealed class ConnectionStateBrushConverter : IValueConverter
{
    /// <summary>
    /// ConnectionState 값을 Brush로 변환합니다.
    /// </summary>
    /// <param name="value">변환할 값입니다.</param>
    /// <param name="targetType">대상 타입입니다.</param>
    /// <param name="parameter">변환 파라미터입니다.</param>
    /// <param name="culture">문화권 정보입니다.</param>
    /// <returns>상태 표시용 Brush입니다.</returns>
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
    /// Brush를 ConnectionState로 역변환합니다.
    /// </summary>
    /// <param name="value">변환할 값입니다.</param>
    /// <param name="targetType">대상 타입입니다.</param>
    /// <param name="parameter">변환 파라미터입니다.</param>
    /// <param name="culture">문화권 정보입니다.</param>
    /// <returns>지원하지 않으므로 Binding.DoNothing을 반환합니다.</returns>
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return Binding.DoNothing;
    }
}
