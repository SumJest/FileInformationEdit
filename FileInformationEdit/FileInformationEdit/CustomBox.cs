using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileInformationEdit
{
    class CustomBox
    {
        private CustomBox() { }

        public static void Show(){
            Form f = new MsgBox();
            f.ShowDialog();
        }




    }
}
