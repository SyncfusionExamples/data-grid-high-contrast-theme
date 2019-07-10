using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ThemeDemo
{
    public class Employee : INotifyPropertyChanged
    {
        #region Private Members

        private bool _selected;
        private string _name;
        private string _designation;
        private string _mail;
        private string _trust;
        private string _status;
        private int _proficiency;
        private int _rating;
        private int _salary;
        private string _address;
        private string _gender;


        #endregion

        public Employee(bool selected, string name, string designation, string mail, string location, string trust, int rating, string status, int proficiency, int salary, string address, string gender)
        {
            Selected = selected;
            EmployeeName = name;
            Designation = designation;
            Mail = mail;
            Location = location;
            Trustworthiness = trust;
            Rating = rating;
            Status = status;
            SoftwareProficiency = proficiency;
            Salary = salary;
            Address = address;
            Gender = gender;
        }

        /// <summary>
        /// Related to row selection though check box.
        /// </summary>   
        public bool Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
                RaisePropertyChanged("Selected");
            }
        }

        /// <summary>
        /// Gets or sets the employee name.
        /// </summary>        
        [Display(Name = "Employee Name ")]
        public string EmployeeName
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                RaisePropertyChanged("EmployeeName");
            }
        }

        /// <summary>
        /// Gets or sets the designation.
        /// </summary>        
        [Display(Name = "Designation ")]
        public string Designation
        {
            get
            {
                return _designation;
            }
            set
            {
                _designation = value;
                RaisePropertyChanged("Designation");
            }
        }

        /// <summary>
        /// Gets or sets the e-mail ID.
        /// </summary>        
        [Display(Name = "Mail")]
        public string Mail
        {
            get
            {
                return _mail;
            }
            set
            {
                _mail = value;
                RaisePropertyChanged("Mail");
            }
        }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>        
        [Display(Name = "Location")]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the trustworthiness.
        /// </summary>        
        [Display(Name = "Trustworthiness")]
        public string Trustworthiness
        {
            get
            {
                return _trust;
            }
            set
            {
                _trust = value;
                RaisePropertyChanged("Trustworthiness");
            }
        }

        /// <summary>
        /// Gets or sets the rating.
        /// </summary>        
        [Display(Name = "Rating")]
        public int Rating
        {
            get
            {
                return _rating;
            }
            set
            {
                _rating = value;
                RaisePropertyChanged("Rating");
            }
        }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>        
        [Display(Name = "Status")]
        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                RaisePropertyChanged("Status");
            }
        }

        /// <summary>
        /// Gets or sets the software proficiency .
        /// </summary>        
        [Display(Name = "Software Proficiency")]
        public int SoftwareProficiency
        {
            get
            {
                return _proficiency;
            }
            set
            {
                _proficiency = value;
                RaisePropertyChanged("SoftwareProficiency");
            }
        }

        /// <summary>
        /// Gets or sets the salary.
        /// </summary>        
        [Display(Name = "Salary")]
        public int Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                _salary = value;
                RaisePropertyChanged("Salary");
            }
        }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>        
        [Display(Name = "Address")]
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
                RaisePropertyChanged("Address");
            }
        }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>        
        [Display(Name = "Gender")]
        public string Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                _gender = value;
                RaisePropertyChanged("Gender");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}