using System;
using System.ComponentModel;

namespace SchoolApp
{
	public abstract class ViewModelBase : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			var handler = PropertyChanged;

			if (handler == null)
				return;

			handler(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
