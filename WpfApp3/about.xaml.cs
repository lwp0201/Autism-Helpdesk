using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for about.xaml
    /// </summary>
    public partial class about : Window
    {
        public about()
        {
            InitializeComponent();
            StreamReader reader = new StreamReader(@"Assets/about.txt");
            //txtBox.Text = reader.ReadToEnd();
            aboutext.Document.Blocks.Clear();
            Paragraph howto = new Paragraph(new Run(reader.ReadToEnd()));
            aboutext.Document.Blocks.Add(howto);
            howto.FontSize = 16;
            reader.Close();
        }
    }
}
