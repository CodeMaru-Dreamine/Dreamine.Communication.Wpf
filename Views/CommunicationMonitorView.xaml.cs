using System.Windows.Controls;
using Dreamine.Communication.Wpf.ViewModels;

namespace Dreamine.Communication.Wpf.Views;

/// <summary>
/// \brief Dreamine Communication 상태와 메시지 로그를 표시하는 WPF UserControl입니다.
/// </summary>
public partial class CommunicationMonitorView : UserControl
{
    /// <summary>
    /// \brief CommunicationMonitorView 클래스의 새 인스턴스를 초기화합니다.
    /// </summary>
    public CommunicationMonitorView()
    {
        InitializeComponent();

        if (DataContext is null)
        {
            DataContext = new CommunicationMonitorViewModel();
        }
    }
}