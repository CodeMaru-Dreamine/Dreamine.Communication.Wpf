using System;
using System.Windows.Input;

namespace Dreamine.Communication.Wpf.Commands;

/// <summary>
/// \brief WPF 명령 실행을 위한 기본 DelegateCommand입니다.
/// </summary>
public sealed class DelegateCommand : ICommand
{
    private readonly Action<object?> _execute;
    private readonly Predicate<object?>? _canExecute;

    /// <summary>
    /// \brief DelegateCommand 클래스의 새 인스턴스를 초기화합니다.
    /// </summary>
    /// <param name="execute">명령 실행 동작입니다.</param>
    /// <param name="canExecute">명령 실행 가능 여부를 판단하는 조건입니다.</param>
    public DelegateCommand(Action<object?> execute, Predicate<object?>? canExecute = null)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canExecute;
    }

    /// <summary>
    /// \brief 명령 실행 가능 여부가 변경될 때 발생합니다.
    /// </summary>
    public event EventHandler? CanExecuteChanged;

    /// <summary>
    /// \brief 명령 실행 가능 여부를 반환합니다.
    /// </summary>
    /// <param name="parameter">명령 파라미터입니다.</param>
    /// <returns>실행 가능하면 true입니다.</returns>
    public bool CanExecute(object? parameter)
    {
        return _canExecute?.Invoke(parameter) ?? true;
    }

    /// <summary>
    /// \brief 명령을 실행합니다.
    /// </summary>
    /// <param name="parameter">명령 파라미터입니다.</param>
    public void Execute(object? parameter)
    {
        _execute(parameter);
    }

    /// <summary>
    /// \brief CanExecuteChanged 이벤트를 발생시킵니다.
    /// </summary>
    public void RaiseCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}