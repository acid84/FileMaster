using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;

namespace FileMaster.UI.ViewModels
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		private readonly Dictionary<string, object> _values = new Dictionary<string, object>();
		public event PropertyChangedEventHandler PropertyChanged;

		protected void NotifyPropertyChanged(String info)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(info));
			}
		}

		#region GET
		protected T Get<T>(Expression<Func<T>> expression)
		{
			return Get<T>(PropertyName(expression));
		}

		private T Get<T>(string name, T defaultValue = default(T))
		{
			if (_values.ContainsKey(name))
			{
				return (T)_values[name];
			}

			return defaultValue;
		}

		private static string PropertyName<T>(Expression<Func<T>> expression)
		{
			var memberExpression = expression.Body as MemberExpression;

			if (memberExpression == null)
				throw new ArgumentException("expression must be a property expression");

			return memberExpression.Member.Name;
		}
		#endregion

		#region SET
		protected void Set<T>(Expression<Func<T>> expression, T value)
		{
			Set(PropertyName(expression), value);
		}

		public void Set<T>(string name, T value)
		{
			if (_values.ContainsKey(name))
			{
				if (_values[name] == null && value == null)
					return;

				if (_values[name] != null && _values[name].Equals(value))
					return;

				_values[name] = value;
			}
			else
			{
				_values.Add(name, value);
			}

			NotifyPropertyChanged(name);
		}
		#endregion
	}
}
