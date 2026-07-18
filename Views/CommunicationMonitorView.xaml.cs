using System.Windows.Controls;

namespace Dreamine.Communication.Wpf.Views;

/// <summary>
/// \if KO
/// <para>Dreamine 통신 채널 상태와 메시지 로그를 표시하는 WPF 사용자 컨트롤입니다.</para>
/// \endif
/// \if EN
/// <para>Provides a WPF user control that displays Dreamine communication channel states and message logs.</para>
/// \endif
/// </summary>
public partial class CommunicationMonitorView : UserControl
{
    /// <summary>
    /// \if KO
    /// <para>XAML 구성 요소를 로드하여 통신 모니터 View를 초기화합니다.</para>
    /// \endif
    /// \if EN
    /// <para>Initializes the communication monitor view by loading its XAML components.</para>
    /// \endif
    /// </summary>
    public CommunicationMonitorView()
    {
        InitializeComponent();
    }
}
