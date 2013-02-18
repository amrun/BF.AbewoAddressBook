using System.Data.Entity;

namespace BF.AbewoAdressBook.Entities
{
	public class Person
	{
		/// <summary>
		/// Gets or sets the person id.
		/// </summary>
		/// <value>
		/// The person id.
		/// </value>
		public int personId
		{
			get;
			set;
		}
		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Person"/> is gender.
		/// </summary>
		/// <value>
		///   <c>true</c> if gender; otherwise, <c>false</c>.
		/// </value>
		public bool Gender
		{
			get;
			set;
		}
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		public string Name
		{
			get;
			set;
		}
		/// <summary>
		/// Gets or sets the surname.
		/// </summary>
		/// <value>
		/// The surname.
		/// </value>
		public string Surname
		{
			get;
			set;
		}
		/// <summary>
		/// Gets or sets the street.
		/// </summary>
		/// <value>
		/// The street.
		/// </value>
		public string Street
		{
			get;
			set;
		}
		/// <summary>
		/// Gets or sets the street nr.
		/// </summary>
		/// <value>
		/// The street nr.
		/// </value>
		public string StreetNr
		{
			get;
			set;
		}
		/// <summary>
		/// Gets or sets the PLZ.
		/// </summary>
		/// <value>
		/// The PLZ.
		/// </value>
		public string Plz
		{
			get;
			set;
		}
		/// <summary>
		/// Gets or sets the city.
		/// </summary>
		/// <value>
		/// The city.
		/// </value>
		public string City
		{
			get;
			set;
		}
		/// <summary>
		/// Gets or sets the email.
		/// </summary>
		/// <value>
		/// The email.
		/// </value>
		public string Email
		{
			get;
			set;
		}
		//public Company Company { get; set; }

	}



}
