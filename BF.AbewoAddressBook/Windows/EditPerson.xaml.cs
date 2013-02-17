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
using System.Windows.Shapes;
using BF.AbewoAdressBook.Entities;

namespace BF.AbewoAdressBook.Windows
{
	/// <summary>
	/// Interaction logic for EditPerson.xaml
	/// </summary>
	public partial class EditPerson: Window
	{

		public EditPerson( Person person )
		{
			InitializeComponent();
			pp = person;
			TbEditEMail.Text = pp.Email;
			TbEditSurname.Text = pp.Surname;
			TbEditName.Text = pp.Name;
			TbEditPlz.Text = pp.Plz;
			TbEditStreet.Text = pp.Street;
			TbEditStreetNr.Text = pp.StreetNr;
		}

		private void PersonButtonUpdateClick( object sender, RoutedEventArgs e )
		{
			pp.Name = TbEditName.Text;

			Octopus.UpdatePerson( pp );
		}

		protected Person pp
		{
			get;
			set;
		}

		private void ButtonCancelClick( object sender, RoutedEventArgs e )
		{
			this.Close();
		}
	}
}
