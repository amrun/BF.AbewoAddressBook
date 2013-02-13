using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Threading;
using BF.AbewoAdressBook.Entities;

namespace BF.AbewoAdressBook
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow: Window
	{
		public MainWindow()
		{

			Thread.Sleep( 1000 );
			InitializeComponent();
		}

		public void SearchField_TextChanged( object sender, TextChangedEventArgs e )
		{

			List<Person> personList = Main.ReadAllDbContent();




			try
			{
				ResultList.ItemsSource = personList;
			}
			catch
			{
			}
		}



	}
}
