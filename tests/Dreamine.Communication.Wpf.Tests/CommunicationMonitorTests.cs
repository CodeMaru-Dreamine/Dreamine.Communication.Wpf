using System.Text;
using System.Windows.Data;
using System.Windows.Media;
using Dreamine.Communication.Abstractions.Enums;
using Dreamine.Communication.Abstractions.Models;
using Dreamine.Communication.Wpf.Commands;
using Dreamine.Communication.Wpf.Converters;
using Dreamine.Communication.Wpf.Models;
using Dreamine.Communication.Wpf.ViewModels;
using Xunit;

namespace Dreamine.Communication.Wpf.Tests;

public sealed class CommunicationMonitorTests
{
    [Fact]
    public void DelegateCommand_ExecutesAndRaisesStateChange()
    {
        object? received = null;
        var raised = false;
        var command = new DelegateCommand(value => received = value, value => value is string);
        command.CanExecuteChanged += (_, _) => raised = true;

        Assert.True(command.CanExecute("message"));
        Assert.False(command.CanExecute(42));
        command.Execute("payload");
        command.RaiseCanExecuteChanged();

        Assert.Equal("payload", received);
        Assert.True(raised);
    }

    [Fact]
    public void DelegateCommand_RejectsNullExecutor()
    {
        Assert.Throws<ArgumentNullException>(() => new DelegateCommand(null!));
    }

    [Fact]
    public void ChannelItem_RaisesPropertyChangedOnlyForChanges()
    {
        var item = new CommunicationChannelViewItem();
        var changed = new List<string?>();
        item.PropertyChanged += (_, args) => changed.Add(args.PropertyName);

        item.Name = "TCP";
        item.Name = "TCP";
        item.State = ConnectionState.Connected;

        Assert.Equal(["Name", "State"], changed);
    }

    [Fact]
    public void ViewModel_ManagesChannelsAndSelection()
    {
        var viewModel = new CommunicationMonitorViewModel();
        var selectedChanged = false;
        viewModel.PropertyChanged += (_, args) => selectedChanged |= args.PropertyName == nameof(viewModel.SelectedChannel);

        viewModel.AddChannel("primary", TransportKind.Tcp, "Main channel");
        viewModel.AddChannel("primary", TransportKind.Tcp);
        viewModel.UpdateChannelState("primary", ConnectionState.Connected);
        viewModel.UpdateChannelDescription("primary", null!);
        viewModel.SelectedChannel = viewModel.Channels[0];

        var channel = Assert.Single(viewModel.Channels);
        Assert.Equal(ConnectionState.Connected, channel.State);
        Assert.Equal(string.Empty, channel.Description);
        Assert.True(selectedChanged);
    }

    [Fact]
    public void ViewModel_ValidatesChannelNames()
    {
        var viewModel = new CommunicationMonitorViewModel();

        Assert.Throws<ArgumentException>(() => viewModel.AddChannel(" ", TransportKind.Tcp));
        Assert.Throws<ArgumentException>(() => viewModel.UpdateChannelState("", ConnectionState.Connected));
        Assert.Throws<ArgumentException>(() => viewModel.UpdateChannelDescription("", "description"));
    }

    [Fact]
    public void ViewModel_AddsSendAndReceiveLogsAndClearsThem()
    {
        var viewModel = new CommunicationMonitorViewModel();
        var payload = Encoding.UTF8.GetBytes(new string('a', 121));
        var message = new MessageEnvelope { Name = "status", Route = "devices/1", Payload = payload };

        viewModel.AddSendLog("primary", TransportKind.Tcp, message);
        viewModel.AddReceiveLog("primary", TransportKind.Tcp, new MessageEnvelope());

        Assert.Equal(2, viewModel.Logs.Count);
        Assert.Equal("RECV", viewModel.Logs[0].Direction);
        Assert.Equal(string.Empty, viewModel.Logs[0].PayloadPreview);
        Assert.Equal("SEND", viewModel.Logs[1].Direction);
        Assert.Equal(123, viewModel.Logs[1].PayloadPreview.Length);
        Assert.EndsWith("...", viewModel.Logs[1].PayloadPreview);

        viewModel.ClearLogsCommand.Execute(null);
        Assert.Empty(viewModel.Logs);
    }

    [Fact]
    public void ViewModel_ValidatesLogArguments()
    {
        var viewModel = new CommunicationMonitorViewModel();
        var message = new MessageEnvelope();

        Assert.Throws<ArgumentException>(() => viewModel.AddSendLog("", TransportKind.Tcp, message));
        Assert.Throws<ArgumentNullException>(() => viewModel.AddReceiveLog("primary", TransportKind.Tcp, null!));
    }

    [Theory]
    [InlineData(ConnectionState.Connected, "#FF228B22")]
    [InlineData(ConnectionState.Listening, "#FF228B22")]
    [InlineData(ConnectionState.Connecting, "#FFFF8C00")]
    [InlineData(ConnectionState.Disconnecting, "#FFFF8C00")]
    [InlineData(ConnectionState.Faulted, "#FFB22222")]
    [InlineData(ConnectionState.Disconnected, "#FF808080")]
    public void Converter_MapsConnectionStates(ConnectionState state, string expected)
    {
        var converter = new ConnectionStateBrushConverter();

        var brush = Assert.IsType<SolidColorBrush>(
            converter.Convert(state, typeof(Brush), null!, System.Globalization.CultureInfo.InvariantCulture));

        Assert.Equal(expected, brush.ToString());
    }

    [Fact]
    public void Converter_HandlesUnsupportedValuesAndBackConversion()
    {
        var converter = new ConnectionStateBrushConverter();

        Assert.Same(Brushes.Gray, converter.Convert("invalid", typeof(Brush), null!, System.Globalization.CultureInfo.InvariantCulture));
        Assert.Same(Binding.DoNothing, converter.ConvertBack(Brushes.Gray, typeof(ConnectionState), null!, System.Globalization.CultureInfo.InvariantCulture));
    }
}
