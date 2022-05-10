using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMIS_G19.Models;

namespace GMIS_G19.Controllers
{
	public class MastersStudentController
	{
		public ObservableCollection<Student> FilteredStudent
		{
			get { return _FilteredStudent; }
			set
			{
				_FilteredStudent = value;
				FilteredClass = new ObservableCollection<Class>(Classes.Where(cls =>
					FilteredStudent.Select(student => student.GroupId).Contains(cls.GroupId)));
			}
		}

		public ObservableCollection<Class> FilteredClass { get; set; }

		public ObservableCollection<Student> Students =>
			new ObservableCollection<Student>(_Repository.GetAllStudents());

		public ObservableCollection<Class> Classes => new ObservableCollection<Class>(_Repository.GetAllClasses());
		private Repository.Repository _Repository;
		private ObservableCollection<Student> _FilteredStudent;


		public MastersStudentController()
		{
			_Repository = new Repository.Repository();
			FilteredClass = Classes;
			FilteredStudent = Students;
		}

		public void FilterStudentByClassId(string classId)
		{
			if (classId == "All")
			{
				FilteredStudent = new ObservableCollection<Student>(Students);
			}
			else
			{
				var id = int.Parse(classId);
				var groupId = Classes.Where(cls => cls.Id == id).Select(cls => cls.GroupId);
				FilteredStudent =
					new ObservableCollection<Student>(Students.Where(student => groupId.Contains(student.GroupId)));
			}
		}

		public void FilterStudentByGroupId(string groupId)
		{
			if (groupId == "All")
			{
				FilteredStudent = new ObservableCollection<Student>(Students);
			}
			else
			{
				var id = int.Parse(groupId);
				FilteredStudent =
					new ObservableCollection<Student>(Students.Where(student => student.GroupId == id));
			}
		}
	}
}