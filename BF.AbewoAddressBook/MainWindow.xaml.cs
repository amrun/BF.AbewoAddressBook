using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Threading;
using BF.AbewoAdressBook.Entities;
using BF.AbewoAdressBook.Windows;

namespace BF.AbewoAdressBook
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow: Window
	{
		public MainWindow()
		{
			InitializeComponent();
			List<Person> personList = Octopus.GetDbContent();
			try
			{
				ResultList.ItemsSource = personList;
			}
			catch( Exception m )
			{
			}
		}

		public void SearchField_TextChanged( object sender, TextChangedEventArgs e )
		{

			List<Person> personList = Octopus.GetDbContent( SearchField.Text );

			try
			{
				ResultList.ItemsSource = personList;
			}
			catch
			{
			}
		}


		private void UIElement_OnGotFocus( object sender, RoutedEventArgs e )
		{
			var textBox = e.OriginalSource as TextBox;
			if( textBox != null )
				textBox.SelectAll();
		}

		private void PersonButtonSaveClick( object sender, RoutedEventArgs e )
		{
			Person person = new Person();
			person.Name = TbName.Text;
			person.Surname = TbSurname.Text;
			person.Street = TbStreet.Text;
			person.StreetNr = TbStreetNr.Text;
			person.Email = TbEMail.Text;

			Octopus.SavePerson( person );

		}

		private void PersonButtonEditPerson( object sender, RoutedEventArgs e )
		{
			ResultList.SelectedItem = ( (Button)sender ).DataContext;
			Person editPerson = (Person)ResultList.SelectedItem;

			Window editWindow = new EditPerson( editPerson );
			editWindow.ShowDialog();
		}
	}
}
