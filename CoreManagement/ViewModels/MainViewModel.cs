using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CoreManagement.ViewModels
{
    
    public class MainViewModel
    {
        public MainViewModel()
        {
            InitLogin();
        }

        private void InitLogin()
        {
            ServiceReference1.CoreServiceClient proxy = new ServiceReference1.CoreServiceClient();
            ServiceReference1.User _user = new ServiceReference1.User();
            try
            {
                if (_user.Fullname == "failed")
                {
                    MessageBox.Show("Login Failed");
                }
                else
                {
                    _user = proxy.VerifyLogin("leon", "passwrd");
                    MessageBox.Show("USER=" + _user.Fullname);
                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message+":"+_user.Fullname);
            }
            
            
            
        }
    }


}
