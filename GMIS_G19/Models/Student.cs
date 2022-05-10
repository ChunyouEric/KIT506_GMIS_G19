namespace GMIS_G19.Models
{
	public enum Campus
	{
		Hobart,
		Launceston
	};

	public enum Category
	{
		Bachelors,
		Masters
	};

	public class Student
	{
		public int Id { get; set; }
		public string GivenName { get; set; }
		public string FamilyName { get; set; }
		public int GroupId { get; set; }
		public string Title { get; set; }
		public Campus Campus { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }

		public string Photo { get; set; }

		public Category Category { get; set; }
	}
}