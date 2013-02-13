using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

using System.Data.Entity;

using BF.AbewoAddressBook.Entities;

namespace BF.AbewoAddressBook
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

			List<Person> personList = new List<Person>();
			Person p1 = new Person();
			p1.Name = "Hans Meier";
			p1.Email = "hansmeier@meier.ch";

			Person p2 = new Person();
			p2.Name = "Joggeli Müller";
			p2.Email = "joggi@meier.ch";

			personList.Add( p1 );
			personList.Add( p2 );
			try
			{
				ResultList.ItemsSource = personList;
			}
			catch { 
			}
		}



	}
}
