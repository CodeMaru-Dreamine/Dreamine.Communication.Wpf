using System;
using System.Windows.Input;

namespace Dreamine.Communication.Wpf.Commands;

/// <summary>
/// \if KO
/// <para>실행 및 선택적 실행 가능 조건 대리자로 구성되는 WPF 명령입니다.</para>
/// \endif
/// \if EN
/// <para>Provides a WPF command backed by execution and optional can-execute delegates.</para>
/// \endif
/// </summary>
public sealed class DelegateCommand : ICommand
{
    /// <summary>
    /// \if KO
    /// <para>execute 값을 보관합니다.</para>
    /// \endif
    /// \if EN
    /// <para>Stores the execute value.</para>
    /// \endif
    /// </summary>
    private readonly Action<object?> _execute;
    /// <summary>
    /// \if KO
    /// <para>can Execute 값을 보관합니다.</para>
    /// \endif
    /// \if EN
    /// <para>Stores the can execute value.</para>
    /// \endif
    /// </summary>
    private readonly Predicate<object?>? _canExecute;

    /// <summary>
    /// \if KO
    /// <para>실행 대리자와 선택적 실행 가능 조건으로 명령을 초기화합니다.</para>
    /// \endif
    /// \if EN
    /// <para>Initializes the command with an execution delegate and optional can-execute predicate.</para>
    /// \endif
    /// </summary>
    /// <param name="execute">
    /// \if KO
    /// <para>명령 호출 시 실행할 동작입니다.</para>
    /// \endif
    /// \if EN
    /// <para>The action invoked when the command executes.</para>
    /// \endif
    /// </param>
    /// <param name="canExecute">
    /// \if KO
    /// <para>현재 매개변수로 실행 가능한지 판단할 조건이며, <see langword="null"/>이면 항상 가능합니다.</para>
    /// \endif
    /// \if EN
    /// <para>The predicate that determines whether the command can execute; <see langword="null"/> always permits execution.</para>
    /// \endif
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// \if KO
    /// <para><paramref name="execute"/>가 <see langword="null"/>인 경우 발생합니다.</para>
    /// \endif
    /// \if EN
    /// <para>Thrown when <paramref name="execute"/> is <see langword="null"/>.</para>
    /// \endif
    /// </exception>
    public DelegateCommand(Action<object?> execute, Predicate<object?>? canExecute = null)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canExecute;
    }

    /// <summary>
    /// \if KO
    /// <para>명령 실행 가능 상태를 다시 평가해야 할 때 발생합니다.</para>
    /// \endif
    /// \if EN
    /// <para>Occurs when the command's ability to execute should be reevaluated.</para>
    /// \endif
    /// </summary>
    public event EventHandler? CanExecuteChanged;

    /// <summary>
    /// \if KO
    /// <para>선택적 조건 대리자를 사용해 현재 명령 실행 가능 여부를 확인합니다.</para>
    /// \endif
    /// \if EN
    /// <para>Determines whether the command can execute by evaluating the optional predicate.</para>
    /// \endif
    /// </summary>
    /// <param name="parameter">
    /// \if KO
    /// <para>조건에 전달할 명령 매개변수입니다.</para>
    /// \endif
    /// \if EN
    /// <para>The command parameter passed to the predicate.</para>
    /// \endif
    /// </param>
    /// <returns>
    /// \if KO
    /// <para>실행 가능하면 <see langword="true"/>입니다.</para>
    /// \endif
    /// \if EN
    /// <para><see langword="true"/> when the command can execute.</para>
    /// \endif
    /// </returns>
    public bool CanExecute(object? parameter)
    {
        return _canExecute?.Invoke(parameter) ?? true;
    }

    /// <summary>
    /// \if KO
    /// <para>구성된 실행 대리자를 호출합니다.</para>
    /// \endif
    /// \if EN
    /// <para>Invokes the configured execution delegate.</para>
    /// \endif
    /// </summary>
    /// <param name="parameter">
    /// \if KO
    /// <para>실행 대리자에 전달할 명령 매개변수입니다.</para>
    /// \endif
    /// \if EN
    /// <para>The command parameter passed to the execution delegate.</para>
    /// \endif
    /// </param>
    public void Execute(object? parameter)
    {
        _execute(parameter);
    }

    /// <summary>
    /// \if KO
    /// <para>명령 소비자가 실행 가능 상태를 다시 평가하도록 이벤트를 발생시킵니다.</para>
    /// \endif
    /// \if EN
    /// <para>Raises the event so command consumers reevaluate can-execute state.</para>
    /// \endif
    /// </summary>
    public void RaiseCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
