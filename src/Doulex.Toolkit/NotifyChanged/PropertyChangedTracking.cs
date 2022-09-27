using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Doulex.Toolkit.NotifyChanged;

/// <summary>
/// 该类配合 PropertyChanged.Fody 实现更改属性的跟踪和记录的功能
/// 可以用于 Asp.NET 项目从请求进来的 DTO 对象所附带的属性信息
/// 也可用于 ViewModel 中的属性跟踪
///
/// 有新的属性被设置时，Fody 会自动调用 OnPropertyChanged 方法
/// 目前还有一个 Fody 的替代方案: PropertyChanged.SourceGenerator 但是没有测试过
/// </summary>
public class PropertyChangedTracking : INotifyPropertyChanged
{
    private readonly HashSet<string> _propertyNames = new();

    public bool HasChanged(string propertyName)
    {
        var result = _propertyNames.Contains(propertyName);
        return result;
    }

    public void AcceptChanges()
    {
        _propertyNames.Clear();
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        if (propertyName != null)
            _propertyNames.Add(propertyName);

        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
