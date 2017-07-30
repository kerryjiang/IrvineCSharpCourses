using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SchoolApp
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<Student> Students { get; set; }

        public MainViewModel()
        {
            SchoolName = "Woodbridge High School";
            Students = new ObservableCollection<Student>();
            GetStudentsAsync();			
        }

        private async void GetStudentsAsync()
        {
            var client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;

            using (var response = await client.GetAsync(new Uri("http://localhost:5000/api/student")).ConfigureAwait(false))
            {
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var students = JsonConvert.DeserializeObject<List<Student>>(content);

                    if (students == null)
                        return;

                    foreach (var s in students)
                    {
                        Students.Add(s);
                    }

                    StudentCount = students.Count;
                }
            }
        }


        private string _schoolName;

        public string SchoolName
        {
            get { return _schoolName; }
            set
            {
                _schoolName = value;
                OnPropertyChanged("SchoolName");
            }
        }

        private int _studentCount = 0;

        public int StudentCount
        {
            get { return _studentCount; }
            set
            {
                _studentCount = value;
                OnPropertyChanged("StudentCount");
            }
        }
    }
}
