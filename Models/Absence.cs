using Catel.Data;
using Catel.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogInForm.Models
{
    public class Absence: ViewModelBase
    {

        public string Name
        {
            get { return GetValue<string>(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        public static readonly PropertyData NameProperty = RegisterProperty(nameof(Name), typeof(string), null);


        public string Abriviature
        {
            get { return GetValue<string>(AbriviatureProperty); }
            set { SetValue(AbriviatureProperty, value); }
        }

        public static readonly PropertyData AbriviatureProperty = RegisterProperty(nameof(Abriviature), typeof(string), null);

        public int ID { get; set; }


        public bool IsSelectedForDelete
        {
            get { return GetValue<bool>(IsSelectedForDeleteProperty); }
            set { SetValue(IsSelectedForDeleteProperty, value); }
        }

        public static readonly PropertyData IsSelectedForDeleteProperty = RegisterProperty(nameof(IsSelectedForDelete), typeof(bool), false);



        public int Days
        {
            get { return GetValue<int>(DaysProperty); }
            set { SetValue(DaysProperty, value); }
        }

        public static readonly PropertyData DaysProperty = RegisterProperty(nameof(Days), typeof(int), null);
    }
}
